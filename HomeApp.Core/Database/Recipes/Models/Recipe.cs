using System.Collections.Generic;

namespace HomeApp.Core.Databse.Recipes.Models
{
    public class Recipe
    {
        public Recipe(int recipeId, string url, string recipeText, List<string> recipeMaterials)
        {
            RecipeId = recipeId;
            Url = url;
            RecipeText = recipeText;
            RecipeMaterials = recipeMaterials;
        }

        public int RecipeId { get; private set; }
        public string Url { get; private set; }
        public string RecipeText { get; private set; }
        public List<string> RecipeMaterials { get; private set; }


    }
}
