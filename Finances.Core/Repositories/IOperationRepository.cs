using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Core.Repositories
{
    public interface IOperationRepository
    {
        Task<Operation> GetAsync(Guid id);

        Task<Operation> GetAsync(string name);

        Task<IList<Operation>> GetAllAsync();

        Task AddAsync(Operation operation);

        Task UpdateAsync(Operation operation);

        Task DeleteAsync(Operation operation);

    }
}
