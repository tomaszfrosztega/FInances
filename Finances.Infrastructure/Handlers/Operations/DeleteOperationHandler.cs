using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Operations;
using Finances.Infrastructure.IServices;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Operations
{
    public class DeleteOperationHandler : ICommandHandler<DeleteOperation>
    {
        private readonly IOperationServices _operationService;

        public DeleteOperationHandler(IOperationServices operationService)
        {
            _operationService = operationService;
        }
        public async Task HandleAsync(DeleteOperation command)
        {
            await _operationService.DeleteAsync(command.UserId);
        }
    }
}
