using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface IOperationServices
    {
        Task AddAsync(string name, decimal value);

        Task<OperationDTO> GetAsync(string name);

        Task<IList<OperationDTO>> GetAllAsync();
    }
}
