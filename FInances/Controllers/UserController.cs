using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Finances.Infrastructure.DTO;
using Finances.Infrastructure.Services;

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
        public UserDTO Get(string email)
        => _userService.Get(email);
    }
}