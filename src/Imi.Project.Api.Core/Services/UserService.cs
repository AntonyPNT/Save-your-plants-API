using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //JwtService class here
        private readonly IJwtService _jwtService;
        private readonly IConfiguration _configuration;
        public UserService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IJwtService jwtService)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtService = jwtService;
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var users = await GetUsers().SingleOrDefaultAsync(u => u.Id.Equals(id));
            return users;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return _userManager.Users;
        }

        //public async override Task<ApplicationUser> GetByIdAsync(string id)
        //{
        //    var users = await GetUsers().SingleOrDefaultAsync(u => u.Id.Equals(id));
        //    return users;
        //}

        public async Task<AuthenticateResultModel> Login(string username, string password)
        {
            //check if user exists
            var login = await _signInManager.PasswordSignInAsync(username, password, true, false);
            //var user = await _userManager.FindByNameAsync(username);
            if (!login.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Login failed!" }
                };
            }
            var user = await _userManager.FindByNameAsync(username); //find by email
            //user exists => generate token
            //get the claims
            var claims = (List<Claim>)await _userManager.GetClaimsAsync(user);
            //generate the token
            var token = _jwtService.GenerateToken(claims);
            //serialize the token
            var serializedToken = _jwtService.SerializeToken(token);
            //return the token
            return new AuthenticateResultModel { Success = true, Messages = new List<string> { serializedToken } };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string password)
        {
            //create a user
            var applicationUser = new ApplicationUser
            {
                UserName = username,
                Email = username
            };
            //store in database
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (!result.Succeeded)
            {
                return new AuthenticateResultModel
                {
                    Messages = new List<string> { "Registration failed!" }
                };
            }
            //get the user and add a claim registration-date
            applicationUser = await _userManager.FindByNameAsync(username);
            //add a claim registration-date
            await _userManager.AddClaimAsync(applicationUser,
                new Claim("registration-date", DateTime.Now.ToString("yy-MM-dd")));

            await _userManager.AddClaimAsync(applicationUser,
                new Claim("id", applicationUser.Id));

            await _userManager.AddClaimAsync(applicationUser,
                new Claim("nickname", applicationUser.UserName));

            await _userManager.AddClaimAsync(applicationUser,
                new Claim("email", applicationUser.Email));

            await _userManager.AddClaimAsync(applicationUser,
                new Claim("aproved", applicationUser.HasApprovedTermsAndConditions.ToString()));

            await _userManager.AddClaimAsync(applicationUser,
                new Claim(ClaimTypes.Role, "user"));

            return new AuthenticateResultModel
            {
                Success = true,
                //Messages = new List<string> { "user registered!" }
            };
        }

        //public async Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string password)
        //{
        //    //create a user
        //    var applicationUser = new ApplicationUser
        //    {
        //        UserName = username,
        //        Email = username
        //    };
        //    //store in database
        //    var result = await _userManager.CreateAsync(applicationUser, password);
        //    if (!result.Succeeded)
        //    {
        //        return new AuthenticateResultModel
        //        {
        //            Messages = new List<string> { "Registration failed!" }
        //        };
        //    }
        //    //get the user and add a claim registration-date
        //    applicationUser = await _userManager.FindByNameAsync(username);
        //    //add a claim registration-date
        //    await _userManager.AddClaimAsync(applicationUser,
        //        new Claim("registration-date", DateTime.UtcNow.ToString("yy-MM-dd")));
        //    return new AuthenticateResultModel
        //    {
        //        Success = true,
        //        Messages = new List<string> { "user registered!" }
        //    };
        //}
    }
}
