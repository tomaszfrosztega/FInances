using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using Finances.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>();

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.FirstOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
             =>await Task.FromResult( _users.FirstOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
