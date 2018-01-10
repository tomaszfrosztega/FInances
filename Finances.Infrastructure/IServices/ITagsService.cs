using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface ITagService : IService
    {
        Task AddAsync(string name, Guid categoryId, string operationName);
    }
}
