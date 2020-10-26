using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.Databse.Users.Models;
using HomeApp.Core.HttpModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse?> Authenticate(AuthentiateRequest request);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByUseranem(string username);
    }
}
