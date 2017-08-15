using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core.Domain;

namespace Finances.Infrastructure.Repositories
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private static ISet<Account> _account = new HashSet<Account>
        {
            new Account(0,"RoR"),
            new Account(0,"Savings")
        };

        public  async Task AddAsync(Account account)
            => await Task.FromResult(_account.Add(account));

        public async Task<Account> GetAsync(Guid id)
            => await Task.FromResult(_account.SingleOrDefault(x => x.Id == id));

        public async Task<Account> GetAsync(string name)
                => await Task.FromResult(_account.SingleOrDefault(x => x.AccountName == name));

        public async Task<IEnumerable<Account>> GetAllAsync()
            => await Task.FromResult(_account);

        public async Task UpdateAsync(Account account)
        {
            await Task.CompletedTask;
        }
    }
}
