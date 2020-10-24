using HomeApp.Core.Database;
using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.Repositories.Recipes;
using HomeApp.Test.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HomeApp.Test
{
    public class FilterTest : IDisposable
    {
        private readonly DatabaseFixture _dataFixture;
        private CoreDatabaseContext _testDB;
        private RecipesRepository _repo;
        public FilterTest()
        {
            _dataFixture = new DatabaseFixture();
            _testDB =_dataFixture.DbContext;
            _repo = new RecipesRepository(_testDB);
        }

        public void Dispose()
        {
            _dataFixture.Dispose();
        }

        [Fact(DisplayName = "Should return all recipes")]
        public async Task Test1()
        {
            await _repo.AddRecipe(new Recipe(0, "testUrl", "test", null));
            var results = await _repo.GetRecipes(new Core.DataFilters.PageFilter(1, 100));
            Assert.Single(results);

        }
    }
}
