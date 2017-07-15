using AutoMapper;
using Finances.Core.Domain;
using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Operation, OperationDTO>();
            })
            .CreateMapper();
    }
}
