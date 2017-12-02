using Finances.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Finances.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);

        Task<User> GetAsync(string email);

        Task AddAsync(User user);

        Task UpdateAsync(User user);
    }
}
