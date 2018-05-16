using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.Extensions;
using Finances.Infrastructure.IServices;
using Finances.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Users
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserServices _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly IHandler _handler;

        public LoginHandler(IHandler handler,IUserServices userServices, 
            IJwtHandler jwtHandler, 
            IMemoryCache cache)
        {
            _handler = handler;
            _userService = userServices;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandleAsync(Login command)
            => await _handler
                .Run(async () => await _userService.LoginAsync(command.Email, command.Password))
                .Next()
                .Run(async () =>
                {
                    var user = await _userService.GetAsync(command.Email);
                    var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
                    _cache.SetJwt(command.TokenId, jwt);
                })
                .ExecuteAsync();
    }
}
