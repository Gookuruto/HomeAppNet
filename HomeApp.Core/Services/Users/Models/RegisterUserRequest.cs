using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Services.Users.Models
{
    public class RegisterUserRequest
    {
        public string Username { get; }
        public string Password { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public RegisterUserRequest(string username, string password, string firstName, string lastName)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
