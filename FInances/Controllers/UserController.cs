using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Finances.Infrastructure.Services;
using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.Commands;
using Finances.Api.Controllers;

namespace FInances.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserServices _userService;

        public UserController(IUserServices userService, ICommandDispatcher commandDispatcher)
            :base(commandDispatcher)
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
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"user/{command.Email}", new object());
        }
    }
}