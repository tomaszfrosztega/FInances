using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.IServices;

namespace Finances.Api.Controllers
{
    public class UserAccountController : ApiBaseController
    {
        private readonly IJwtHandler _jwtHandler;

        public UserAccountController(ICommandDispatcher commandDispatcher,
            IJwtHandler jwtHandler) 
            : base(commandDispatcher)
        {
            _jwtHandler = jwtHandler;
        }

        [HttpPut]
        [Route("Password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}
