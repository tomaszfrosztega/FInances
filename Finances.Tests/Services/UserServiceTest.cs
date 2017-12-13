using AutoMapper;
using Finances.Core.Domain;
using Finances.Core.Repositories;
using Finances.Infrastructure.IServices;
using Finances.Infrastructure.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Finances.Tests.Services
{
    public class UserServiceTest : BaseServiceTest<IUserRepository>
    {
        private readonly IUserServices _userService;

        public UserServiceTest() : base(new Mock<IUserRepository>())
        {
            _userService = new UserService(Repository.Object, Encrypter.Object, Mapper.Object);
        }

        [Fact]
        public async Task RegisterAsyncShouldInvokeAddAsyncOnRepository()
        {
            await _userService.RegisterAsync(Guid.NewGuid(),"email@email.com", "janusz", "a");

            Repository.Verify(x=>x.AddAsync(It.IsAny<User>()),Times.Once);
        }
    }
}
