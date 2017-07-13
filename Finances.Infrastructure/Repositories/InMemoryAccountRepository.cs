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

        public void Add(Account account)
            => _account.Add(account);

        public Account Get(Guid id)
            => _account.Single(x => x.Id == id);

        public Account Get(string name)
                => _account.Single(x => x.AccountName == name);

        public IEnumerable<Account> GetAll()
            => _account;

        public void Update(Account account)
        {
        }
    }
}
