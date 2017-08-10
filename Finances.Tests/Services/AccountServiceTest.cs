using AutoMapper;
using Finances.Core.Domain;
using Finances.Core.Repositories;
using Finances.Infrastructure.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Finances.Tests.Services
{
    public class AccountServiceTest : BaseServiceTest<IAccountRepository>
    {
        private readonly IAccountServices _accountService;

        public AccountServiceTest() : base(new Mock<IAccountRepository>())
        {
            _accountService = new AccountService(Repository.Object, Mapper.Object);
        }

        [Fact]
        public async Task AddAsyncShouldInvokeAddAsyncOnRepository()
        {

            await _accountService.AddAsync(1000m, "holiday");

            Repository.Verify(x => x.AddAsync(It.IsAny<Account>()), Times.Once);
        }
    }
}
