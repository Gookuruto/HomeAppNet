using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.DataFilters;
using HomeApp.Core.Repositories.Recipes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Core.Services.Recipes
{
    public class GetRecipesService
    {
        private readonly RecipesRepository _access;

        public GetRecipesService(RecipesRepository access)
        {
            _access = access;
        }

        public async Task<List<Recipe>> GetRecipes(PageFilter filter)
        {
            return await _access.GetRecipes(filter);
        }
    }
}
