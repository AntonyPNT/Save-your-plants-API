using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticateResultModel> Login(string username, string password);
        Task Logout();
        Task<AuthenticateResultModel> Register(string firstname, string lastname, string username, string password
            );
        IQueryable<ApplicationUser> GetUsers();

        Task<ApplicationUser> GetByIdAsync(string id);
    }
}
