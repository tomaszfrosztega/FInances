using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(Guid id);

        User Get(string email);

        void Add(User user);

        void Update(User user);
    }
}
