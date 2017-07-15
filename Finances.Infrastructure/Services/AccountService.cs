using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.DTO;
using Finances.Core.Repositories;
using AutoMapper;
using Finances.Core.Domain;

namespace Finances.Infrastructure.Services
{
    public class AccountService : IAccountServices
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public void AddNewAccount(decimal startValue, string name)
        {
            throw new NotImplementedException();
        }

        public AccountDTO Get(string name)
        {
            var account = _accountRepository.Get(name);

            return _mapper.Map<Account, AccountDTO>(account);
        }
    }
}
