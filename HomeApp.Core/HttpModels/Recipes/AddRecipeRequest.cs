using System;
using System.Collections.Generic;
using System.Text;

namespace HomeApp.Core.HttpModels.Recipes
{
    public class AddRecipeRequest
    {

        public string Url { get; private set; }
        public string RecipeText { get; }
        public List<string> RecipeMaterials { get; }

        public AddRecipeRequest(string url, string recipeText, List<string> recipeMaterials)
        {
            Url = url;
            RecipeText = recipeText;
            RecipeMaterials = recipeMaterials;
        }


    }
}
