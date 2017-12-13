using Finances.Core.Domain;
using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface IOperationTemplateProvider : IService
    {
        Task<IEnumerable<OperationDTO>> BrowseAsync();

        Task<OperationDTO> GetAsync(string category, string name);
    }
}
