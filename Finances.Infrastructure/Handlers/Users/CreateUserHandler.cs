using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserServices _userService;

        public CreateUserHandler(IUserServices userService)
        {
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.UserName, command.Password);
        }
    }
}
