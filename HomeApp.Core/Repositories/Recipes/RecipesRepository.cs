using HomeApp.Core.Database;
using HomeApp.Core.Databse.Recipes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApp.Core.Repositories.Recipes
{
    public class RecipesRepository
    {
        private readonly CoreDatabaseContext _db;

        public RecipesRepository(CoreDatabaseContext db)
        {
            _db = db;
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            return await _db.Recipes.ToListAsync();
        }
    }
}
