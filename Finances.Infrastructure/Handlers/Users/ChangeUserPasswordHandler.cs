using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Users;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Users
{
    public class ChangeUserPasswordHandler : ICommandHandler<ChangeUserPassword>
    {
        public async Task HandleAsync(ChangeUserPassword command)
        {
            await Task.CompletedTask;
        }
    }
}
