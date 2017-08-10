using AutoMapper;
using Finances.Core;
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
    public class CategoryServiceTest : BaseServiceTest<ICategoryRepository>
    {
        private readonly ICategoryServices _categoryService;
        public CategoryServiceTest():base(new Mock<ICategoryRepository>())
        {
            _categoryService = new CategoryService(Repository.Object, Mapper.Object);
        }

        [Fact]
        public async Task AddAsyncShouldInvokeAddAsyncOnRepository()
        {
            await _categoryService.AddAsync("Sport",OperationTypeEnum.Expense);

            Repository.Verify(x => x.AddAsync(It.IsAny<Category>()), Times.Once);
        }
    }
}
