using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.Database.Recipes.Models
{
    public class RecipeProductQuantity
    {

        public int Id { get; private set; }
        public Product? Product { get; set; }
        public double? Quantity { get; private set; }

        private RecipeProductQuantity(int id, double? quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public RecipeProductQuantity(int id, Product? product, double? quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

    }
}
