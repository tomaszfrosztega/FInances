using AutoMapper;
using Finances.Core.Domain;
using Finances.Core.Repositories;
using Finances.Infrastructure.IServices;
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
    public class OperationServiceTest : BaseServiceTest<IOperationRepository>
    {
        private readonly IOperationServices _operationService;

        public OperationServiceTest() : base(new Mock<IOperationRepository>())
        {
            _operationService = new OperationService(Repository.Object, Mapper.Object);
        }

        [Fact]
        public async Task AddAsyncShouldInvokeAddAsyncOnRepository()
        {
            await _operationService.AddAsync("book",20m);

            Repository.Verify(x => x.AddAsync(It.IsAny<Operation>()), Times.Once);
        }
    }
}
