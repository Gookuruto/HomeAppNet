using HomeApp.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Services.Users.Models
{
    public class RegisterUserResponse
    {
        public RegisterUserResponse(Status status, string username)
        {
            Status = status;
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }

        public Status Status { get; }
        public string Username { get; }


    }
}
