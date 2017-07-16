using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public interface IAccountServices
    {
        Task AddAsync(decimal startValue, string name);

        Task<AccountDTO> GetAsync(string name);
    }
}
