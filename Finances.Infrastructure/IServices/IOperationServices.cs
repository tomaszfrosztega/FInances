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
        void Add(string name, decimal value);

        OperationDTO Get(string name);

        IList<OperationDTO> GetAll();
    }
}
