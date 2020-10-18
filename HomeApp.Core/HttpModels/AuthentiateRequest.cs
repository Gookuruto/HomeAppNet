using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeApp.Core.HttpModels
{
    public class AuthentiateRequest
    {
        [Required]
        public string Username { get; }
        [Required]
        public string Password { get; }
        public AuthentiateRequest()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
        [JsonConstructor]
        public AuthentiateRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
