using AutoMapper;
using Moq;

namespace Finances.Tests.Services
{
    public abstract class BaseServiceTest<T> 
        where T : class 
    {
        protected readonly Mock<IMapper> Mapper;
        protected readonly Mock<T> Repository;

        public BaseServiceTest(Mock<T> repository)
        {
            Mapper = new Mock<IMapper>();
            Repository = repository;
        }
    }
}
