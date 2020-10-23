using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HomeApp.Core.Databse.Recipes.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        [JsonIgnore]
        public string Password { get; private set; }

#pragma warning disable CS8618 // Nienullowalne pole jest niezainicjowane. Rozważ zadeklarowanie go jako nullowalnego.
        private User()
#pragma warning restore CS8618 // Nienullowalne pole jest niezainicjowane. Rozważ zadeklarowanie go jako nullowalnego.
        {

        }

        public User(int id,string firstName,string lastName,string username,string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }
    }
}
