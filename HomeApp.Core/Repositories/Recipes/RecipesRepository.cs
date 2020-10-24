using HomeApp.Core.Database;
using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.DataFilters;
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

        public async Task<List<Recipe>> GetRecipes(PageFilter filter)
        {
            return await _db.Recipes.FilterBySearch(filter).ToListAsync();
        }

        public async Task AddRecipe(Recipe recipe)
        {
            using (var db = _db.Database.BeginTransaction())
            {
                try
                {
                    await _db.AddAsync(recipe);
                    _db.SaveChanges();
                    db.Commit();
                }
                catch (Exception ex)
                {
                    db.Rollback();
                }
            }
        }
    }
}
