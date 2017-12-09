using Autofac;
using System;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _componentContext;

        public CommandDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command),
                    $"Command: '{typeof(T).Name}' can not be null");
            }
            var handler = _componentContext.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
