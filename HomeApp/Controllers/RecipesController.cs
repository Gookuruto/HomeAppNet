using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Core.Databse.Recipes.Models;
using HomeApp.Core.Services.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeApp.Controllers
{
    public class RecipesController : Controller
    {
        private readonly GetRecipesService _getRecipesService;

        public RecipesController(GetRecipesService getRecipesService)
        {
            _getRecipesService = getRecipesService;
        }

        // GET: api/<controller>
        [Authorize]
        [HttpGet("api/recipes")]
        [Produces(typeof(List<Recipe>))]
        public async Task<IActionResult> Get()
        {
            var result = await _getRecipesService.GetRecipes();
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
        public void AddNewRecipe([FromBody]string value)
        {
        }
    }
}
