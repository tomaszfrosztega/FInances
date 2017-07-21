using AutoMapper;
using Finances.Core.Domain;
using Finances.Core.Repositories;
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
    public class UserServiceTest
    {
        [Fact]
        public async Task RegisterAsyncShouldInvokeAddAsyncOnRepository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperMock = new Mock<IMapper>();

            var userService = new UserService(userRepositoryMock.Object, mapperMock.Object);
            await userService.RegisterAsync("email@email.com", "janusz", "a");

            userRepositoryMock.Verify(x=>x.AddAsync(It.IsAny<User>()),Times.Once);
        }
    }
}
