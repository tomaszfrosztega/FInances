using Finances.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.Services
{
    public interface IUserServices
    {
        void Register(string email, string username, string password);

        UserDTO Get(string email);
    }
}
