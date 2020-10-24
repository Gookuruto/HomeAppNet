using HomeApp.Core.Database.Recipes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.HttpModels.Recipes
{
    public class AddRecipeRequest
    {

        public string Url { get; private set; }
        public string Name { get; }
        public string RecipeText { get; }
        public List<RecipeProductQuantity> RecipeMaterials { get; }

        public AddRecipeRequest(string url,string name, string recipeText, List<RecipeProductQuantity> recipeMaterials)
        {
            Url = url;
            Name = name;
            RecipeText = recipeText;
            RecipeMaterials = recipeMaterials;
        }


    }
}
