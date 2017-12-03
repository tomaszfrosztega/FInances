using AutoMapper;
using Finances.Infrastructure.IServices;
using Moq;

namespace Finances.Tests.Services
{
    public abstract class BaseServiceTest<T> 
        where T : class 
    {
        protected readonly Mock<IMapper> Mapper;
        protected readonly Mock<T> Repository;
        protected readonly Mock<IEncrypter> Encrypter;

        public BaseServiceTest(Mock<T> repository)
        {
            Mapper = new Mock<IMapper>();
            Repository = repository;
            Encrypter = new Mock<IEncrypter>();
        }
    }
}
