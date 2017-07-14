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
        void Add(string name, OperationTypeEnum defaultOperationType);

        CategoryDTO Get(string name);

        ISet<CategoryDTO> GetAll();
    }
}
