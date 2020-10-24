using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Database.Recipes.Models
{
    public class Product
    {
        public Product(int id, string? name, string? unit)
        {
            Id = id;
            Name = name;
            Unit = unit;
        }

        public int Id { get; private set; }
        public string? Name { get; private set; }
        public string? Unit { get; private set; }
    }
}
