using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Finances.Infrastructure.Services;
using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.Commands;
using Finances.Api.Controllers;
using Finances.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;

namespace FInances.Controllers
{
    public class UserController : ApiBaseController
    {
        private readonly IUserServices _userService;
        private readonly GeneralSettings _settings;

        public UserController(IUserServices userService, ICommandDispatcher commandDispatcher, GeneralSettings settings)
            :base(commandDispatcher)
        {
            _settings = settings;
            _userService = userService;
        }
        
        //[Authorize(Policy ="admin")]
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