using HomeApp.Core.Databse.Users.Models;
using HomeApp.Core.HttpModels.Users;
using HomeApp.Core.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Core.Services.Users
{
    public class UserAdministrationService
    {
        private readonly UsersRepository _usersRepository;

        public UserAdministrationService(UsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
        {
            if (request.Username == null) throw new ArgumentNullException(nameof(request.Username));
            if (request.Password == null) throw new ArgumentNullException(nameof(request.Password));

            var user = new User(0, "", "", request.Username, Sodium.PasswordHash.ArgonHashString(request.Password));
            var result = await _usersRepository.RegisterUser(user);
            return result;
        }
    }
}
