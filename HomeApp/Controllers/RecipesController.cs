using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.DataFilters;
using HomeApp.Core.HttpModels.Recipes;
using HomeApp.Core.Services.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly GetRecipesService _getRecipesService;
        private readonly AddUpdateRecipeService _addUpdateRecipeService;

        public RecipesController(GetRecipesService getRecipesService, AddUpdateRecipeService addUpdateRecipeService)
        {
            _getRecipesService = getRecipesService;
            _addUpdateRecipeService = addUpdateRecipeService;
        }


        // GET: api/<controller>
        [HttpGet("api/recipes")]
        [Authorize]
        [Produces(typeof(List<Recipe>))]
        public async Task<IActionResult> Get(int page,int itemsPerPage,string? sortPropertyName = null, bool descending = false,string? search = "")
        {
            var filter = new PageFilter(page, itemsPerPage, sortPropertyName, descending, search);
            var result = await _getRecipesService.GetRecipes(filter);
            return Ok(result);
        }

        // GET api/<controller>/5
        [HttpGet("api/recipes/{id}")]
        public string GetRecipeById(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost("api/recipes")]
        public async Task<IActionResult> AddNewRecipe([FromBody]AddRecipeRequest value)
        {
            await _addUpdateRecipeService.AddRecipe(value);
            return Ok();
        }
    }
}
