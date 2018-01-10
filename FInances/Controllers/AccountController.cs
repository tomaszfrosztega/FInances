using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Accounts;
using Finances.Infrastructure.DTO;
using Finances.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IAccountServices _accountService;

        public AccountController(IAccountServices accountService, ICommandDispatcher commandDispatcher) :
            base(commandDispatcher)
        {
            _accountService = accountService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var account = await _accountService.GetAsync(name);
            if (account == null)
            {
                return NotFound();
            }
            return Json(account);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAccount command)
        {
            await DispatchAsync(command);
            return Created($"account/{command.Name}", null);
        }
    }
}
