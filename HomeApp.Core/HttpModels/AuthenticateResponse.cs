using HomeApp.Core.Databse.Recipes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.HttpModels
{
    public class AuthenticateResponse
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        [JsonConstructor]
        public AuthenticateResponse(int id, string firstName, string lastName, string username, string token)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Token = token;
        }
        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }
    }
}
