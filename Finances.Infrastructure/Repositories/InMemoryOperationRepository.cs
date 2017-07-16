using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core.Domain;
using Finances.Core;

namespace Finances.Infrastructure.Repositories
{
    public class InMemoryOperationRepository : IOperationRepository
    {
        private static IList<Operation> _operations = new List<Operation>()
        {
            new Operation(new Guid(),new Guid(),100M,"One",DateTime.UtcNow,OperationTypeEnum.Expense),
            new Operation(new Guid(),new Guid(),100M,"Two",DateTime.UtcNow,OperationTypeEnum.Expense)
        };

        public async Task AddAsync(Operation operation)
        {
            _operations.Add(operation);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Operation operation)
        {
            _operations.Remove(operation);
            await Task.CompletedTask;
        }

        public async Task<Operation> GetAsync(Guid id)
            => await Task.FromResult(_operations.Single(x => x.Id == id));

        public async Task<Operation> GetAsync(string name)
            => await Task.FromResult(_operations.Single(x => x.Name == name));

        public async Task<IList<Operation>> GetAllAsync()
        {
            return await Task.FromResult(_operations);
        }

        public async Task UpdateAsync(Operation operation)
        {
            await Task.CompletedTask;
        }
    }
}
