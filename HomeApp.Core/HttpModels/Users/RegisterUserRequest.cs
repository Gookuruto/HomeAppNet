using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.HttpModels.Users
{
    public class RegisterUserRequest
    {
        public string Username { get; }
        public string Password { get; }

        public RegisterUserRequest(string username,string password)
        {
            Username = username;
            Password = password;
        }
    }
}
