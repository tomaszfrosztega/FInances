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

        public void Add(Operation operation)
        {
            _operations.Add(operation);
        }

        public void Delete(Operation operation)
        {
            _operations.Remove(operation);
        }

        public Operation Get(Guid id)
            => _operations.Single(x => x.Id == id);

        public Operation Get(string name)
            => _operations.Single(x => x.Name == name);

        public IEnumerable<Operation> GetAll()
        {
            return _operations;
        }

        public void Update(Operation operation)
        {
        }
    }
}
