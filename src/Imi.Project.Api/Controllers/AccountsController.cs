using Imi.Project.Api.Dtos.Accounts;
using Imi.Project.Api.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Imi.Project.Api.Dtos.Plants;
using Imi.Project.Api.Repositories.Interface;
using Imi.Project.Api.Repositories;
using Imi.Project.Api.Dtos.Schedules;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AccountsController : ControllerBase
    {
        //inject our userService
        private readonly IUserService _userService;
        protected readonly IPlantRepository _plantRepository;
        protected readonly IScheduleRepository _scheduleRepository;

        public AccountsController(IUserService userService, IPlantRepository plantRepository, IScheduleRepository scheduleRepository)
        {
            _userService = userService;
            _plantRepository = plantRepository;
            _scheduleRepository = scheduleRepository;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountsLoginRequestDto accountsLoginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //attempt to log in the user
            var result = await _userService.Login(accountsLoginRequestDto.Username,
                accountsLoginRequestDto.Password);
            if (result.Success)
            {
                return Ok(new AccountsLoginResponseDto { Token = result.Messages.First() });
            }
            return Unauthorized(result.Messages);
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(AccountsRegisterRequestDto accountsRegisterRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //call userservice register method
            var result = await _userService.Register(accountsRegisterRequestDto.Firstname,
                accountsRegisterRequestDto.Lastname,
                accountsRegisterRequestDto.Username,
                accountsRegisterRequestDto.Password
                );
            if (!result.Success)
            {
                return BadRequest(result.Messages);
            }
            return Ok(result.Messages);
        }

        [HttpGet("Users")]
        [Authorize(Policy = "Admin")]
        public IActionResult Users()
        {
            return Ok(_userService.GetUsers().Select(u =>
            new
            {
                u.Id,
                u.Email,
                u.PasswordHash,
                u.UserName
            })) ;
        }


        [HttpGet("{id}/plants")]
        public async Task<IActionResult> GetPlantsFromOwners(string id)
        {
            var plants = await _plantRepository.GetByUsernameIdAsync(id); 

            var plantsDto = plants.Select(p => new PlantResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Condition = p.Condition,
                User = new AccountsResponseDto
                {
                    Id = p.ApplicationUser.Id,
                    Username = p.ApplicationUser.UserName
                }
            });

            return Ok(plantsDto);
        }


        [HttpGet("{id}/schedules")]
        public async Task<IActionResult> GetSchedulesFromOwners(string id)
        {
            var schedules = await _scheduleRepository.GetByUsernameIdAsync(id);

            var schedulesDto = schedules.Select(p => new ScheduleResponseDto
            {
                Id = p.Id,
                Date = p.Date,
                User = new AccountsResponseDto
                {
                    Id = p.ApplicationUser.Id,
                    Username = p.ApplicationUser.UserName
                },
                Plant = new PlantResponseDto 
                { 
                Id = p.Plant.Id,
                Name = p.Plant.Name,
                Condition= p.Plant.Condition,
                DateOfPurchase = p.Plant.DateOfPurchase,
                Image = p.Plant.Image
                }
            });

            return Ok(schedulesDto);
        }
    }
}
