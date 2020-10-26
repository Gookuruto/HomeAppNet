using HomeApp.Core.Database;
using HomeApp.Core.Databse.Users.Models;
using HomeApp.Core.HttpModels.Users;
using System;
using System.Threading.Tasks;

namespace HomeApp.Core.Repositories.Users
{
    public class UsersRepository
    {
        private readonly CoreDatabaseContext _db;

        public UsersRepository(CoreDatabaseContext db)
        {
            _db = db;
        }

        public async Task<RegisterUserResponse> RegisterUser(User userToRegister)
        {
            using (var db = _db.Database.BeginTransaction())
            {
                try
                {
                    await _db.AddAsync(userToRegister);
                    _db.SaveChanges();
                    db.Commit();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                    return new RegisterUserResponse(HttpModels.Users.Common.RegisterStatus.Failure, ex.Message);
                }
                return new RegisterUserResponse(HttpModels.Users.Common.RegisterStatus.Success);
            }
        }
    }
}
