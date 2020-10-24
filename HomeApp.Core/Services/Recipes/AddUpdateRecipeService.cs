using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.HttpModels.Recipes;
using HomeApp.Core.Repositories.Recipes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Core.Services.Recipes
{
    public class AddUpdateRecipeService
    {
        private readonly RecipesRepository _recipesRepositry;

        public AddUpdateRecipeService(RecipesRepository recipesRepositry)
        {
            _recipesRepositry = recipesRepositry;
        }

        public async Task AddRecipe(AddRecipeRequest request)
        {
            if (request == null) return;
            var recipe = new Recipe(0, request.Name, request.Url, request.RecipeText,null);
            await _recipesRepositry.AddRecipe(recipe);
        }
    }
}
