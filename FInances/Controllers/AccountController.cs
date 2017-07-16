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
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountService;

        public AccountController(IAccountServices accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{name}")]
        public async Task<AccountDTO> GetAsync(string name)
            => await _accountService.GetAsync(name);

        [HttpPost]
        public async Task Post([FromBody] CreateAccount account)
        {
            await _accountService.AddAsync(account.Value, account.Name);
        }
    }
}
