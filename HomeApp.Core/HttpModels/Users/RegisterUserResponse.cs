using HomeApp.Core.HttpModels.Users.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.HttpModels.Users
{
    public class RegisterUserResponse
    {
        public RegisterStatus Status { get; }
        public string? Error { get; }
        public RegisterUserResponse(RegisterStatus status, string? error = null)
        {
            Status = status;
            Error = error;
        }

    }
}
