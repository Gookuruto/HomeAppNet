using HomeApp.Core.HttpModels;
using HomeApp.Core.Services;
using HomeApp.Core.Services.Interfaces;
using HomeApp.Core.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserAdministrationService _userAdministrationService;

        public UsersController(IUserService userService, UserAdministrationService userAdministrationService)
        {
            _userService = userService;
            _userAdministrationService = userAdministrationService;
        }

        [HttpPost("api/authenticate")]
        [AllowAnonymous]
        [Produces(typeof(AuthenticateResponse))]
        public async Task<IActionResult> Authenticate([FromBody]AuthentiateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("api/users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}