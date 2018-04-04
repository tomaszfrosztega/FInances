using Finances.Core.Domain;
using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Extensions
{
    public static class RepositortExtensions
    {
        public static async Task<Operation> GetOrFailAsync(this IOperationRepository repository ,Guid OperationId)
        {
            var operation = await repository.GetAsync(OperationId);
            if (operation == null)
            {
                throw new Exception($"Operation with Id {OperationId} was not found");
            }
            return operation;
        }
    }
}
