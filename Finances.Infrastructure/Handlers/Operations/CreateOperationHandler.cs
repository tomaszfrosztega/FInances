using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Operations;
using Finances.Infrastructure.IServices;
using System;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Users
{
    public class CreateOperationHandler : ICommandHandler<CreateOperation>
    {
        private readonly IOperationServices _operationService;

        public CreateOperationHandler(IOperationServices operationService)
        {
            _operationService = operationService;
        }
        public async Task HandleAsync(CreateOperation command)
        {
            await _operationService.AddAsync(command.AccountID,command.CategoryID, command.Name, command.Value, command.OperationType);
        }
    }
}
