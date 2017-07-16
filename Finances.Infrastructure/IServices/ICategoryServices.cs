using Finances.Core;
using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface ICategoryServices
    {
        Task AddAsync(string name, OperationTypeEnum defaultOperationType);

        Task <CategoryDTO> GetAsync(string name);

        Task <ISet<CategoryDTO>> GetAllAsync();
    }
}
