using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using Finances.Infrastructure.Commands.Users;

namespace Finances.Api.Controllers
{
    public class UserAccountController : ApiBaseController
    {
        public UserAccountController(ICommandDispatcher commandDispatcher) 
            : base(commandDispatcher)
        {
        }

        [HttpPut]
        [Route("Password")]
        public async Task<IActionResult> Put([FromBody] ChangeUserPassword command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }
    }
}
