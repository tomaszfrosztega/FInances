using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.Services
{
    public interface IAccountServices
    {
        void AddNewAccount(decimal startValue, string name);

        AccountDTO Get(string name);
    }
}
