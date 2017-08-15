using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Accounts;
using Finances.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Accounts
{
    public class CreateAccountHandler : ICommandHandler<CreateAccount>
    {
        private readonly IAccountServices _operationService;

        public CreateAccountHandler(IAccountServices operationService)
        {
            _operationService = operationService;
        }

        public async Task HandleAsync(CreateAccount command)
        {
            await _operationService.AddAsync(command.Value, command.Name);
        }
    }
}
