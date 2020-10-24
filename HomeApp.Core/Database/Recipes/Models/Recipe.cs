using HomeApp.Core.Database.Recipes.Models;
using System.Collections.Generic;

namespace HomeApp.Core.Databse.Recipes.Models
{
    public class Recipe
    {

        public int RecipeId { get; private set; }
        public string? RecipeName { get; private set; }
        public string? Url { get; private set; }
        public string? RecipeText { get; private set; }
        public List<RecipeProductQuantity>? RecipeMaterials { get; set; }


        private Recipe(int recipeId, string? recipeName, string? url, string? recipeText)
        {
            RecipeId = recipeId;
            RecipeName = recipeName;
            Url = url;
            RecipeText = recipeText;
        }

        public Recipe(int recipeId, string? recipeName, string? url, string? recipeText, List<RecipeProductQuantity>? recipeMaterials)
        {
            RecipeId = recipeId;
            RecipeName = recipeName;
            Url = url;
            RecipeText = recipeText;
            RecipeMaterials = recipeMaterials;
        }


    }
}
