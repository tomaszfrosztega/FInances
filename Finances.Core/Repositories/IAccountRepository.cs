using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Core.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> GetAsync(Guid id);

        Task<Account> GetAsync(string name);

        Task<IEnumerable<Account>> GetAllAsync();

        Task AddAsync(Account account);

        Task UpdateAsync(Account account);
    }
}
