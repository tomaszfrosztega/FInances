using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class LoginController : ApiBaseController
    {
        private readonly IMemoryCache _cache;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache):
            base(commandDispatcher)
        {
            _cache = cache;
        }

        public async Task<IActionResult> Post([FromBody] Login command)
        {
            command.TokenId = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}
