using HomeApp.Core.Database;
using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.HttpModels;
using HomeApp.Core.Services.Common;
using HomeApp.Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Core.Services
{
    public class UserService : IUserService
    {

        private IConfiguration _config;
        //private readonly CoreDatabaseContext _ctx;
        private readonly IServiceScopeFactory _scopeFactory;

        public UserService(IConfiguration config, IServiceScopeFactory scopeFactory)
        {
            _config = config;
            //_ctx = db;
            _scopeFactory = scopeFactory;
        }

        public async Task<AuthenticateResponse?> Authenticate(AuthentiateRequest request)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<CoreDatabaseContext>();
                var user = await db.Users.FirstOrDefaultAsync(x => x.Username == request.Username && x.Password == request.Password);

                // return null if user not found
                if (user == null) return null;

                // authentication successful so generate jwt token
                var token = generateJwtToken(user);
                return new AuthenticateResponse(user, token);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUseranem(string username)
        {
            throw new NotImplementedException();
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //add claims here
            var claims = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
