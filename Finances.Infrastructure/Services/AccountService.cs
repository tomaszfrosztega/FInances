using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.DTO;
using Finances.Core.Repositories;

namespace Finances.Infrastructure.Services
{
    public class AccountService : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void AddNewAccount(decimal startValue, string name)
        {
            throw new NotImplementedException();
        }

        public AccountDTO Get(string name)
        {
            var account = _accountRepository.Get("RoR");

            var accountDto = new AccountDTO
            {
                AccountName = account.AccountName,
                Amount = account.Amount,
                Id = account.Id
            };
            return accountDto;
        }
    }
}
