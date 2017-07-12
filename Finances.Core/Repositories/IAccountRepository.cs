using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Repositories
{
    public interface IAccountRepository
    {
        Account Get(Guid id);

        IEnumerable<Account> GetAll();

        void Add(Account account);

        void Update(Account account);
    }
}
