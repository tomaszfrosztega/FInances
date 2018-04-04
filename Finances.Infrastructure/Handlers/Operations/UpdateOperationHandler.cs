using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Operations;
using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Operations
{
    public class UpdateOperationHandler : ICommandHandler<UpdateOperation>
    {
        private readonly IOperationServices _operationService;

        public UpdateOperationHandler(IOperationServices operationService)
        {
            _operationService = operationService;
        }
        public async Task HandleAsync(UpdateOperation command)
        {
            await _operationService.UpdateAsync(command.Name, command.Value);
        }
    }
}
