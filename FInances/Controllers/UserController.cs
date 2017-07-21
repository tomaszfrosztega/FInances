using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Finances.Infrastructure.DTO;
using Finances.Infrastructure.Services;
using Finances.Infrastructure.Commands.Users;

namespace FInances.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser request)
        {
            await _userService.RegisterAsync(request.Email, request.UserName, request.Password);

            return Created($"user/{request.Email}", new object());
        }
    }
}