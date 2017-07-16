using System;
using Finances.Infrastructure.DTO;
using Finances.Core.Repositories;
using AutoMapper;
using Finances.Core.Domain;
using System.Threading.Tasks;

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

        public async Task AddAsync(decimal startValue, string name)
        {
            var account = new Account(startValue, name);
            await _accountRepository.AddAsync(account);
        }

        public async Task<AccountDTO> GetAsync(string name)
        {
            var account = await _accountRepository.GetAsync(name);

            return _mapper.Map<Account, AccountDTO>(account);
        }
    }
}
