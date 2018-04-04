using Finances.Core;
using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface IOperationServices : IService
    {
        Task AddAsync(Guid accountID, Guid categoryID, string name, decimal value, OperationTypeEnum operationType);
        Task<OperationDetailsDTO> GetAsync(string name);
        Task<IList<OperationDTO>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(string name, decimal value);
    }
}
