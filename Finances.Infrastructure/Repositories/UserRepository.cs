using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core.Domain;
using Finances.Infrastructure.EF;

namespace Finances.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FinancesContext _context;

        public UserRepository(FinancesContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_context.Users.SingleOrDefault(x => x.Email == email));

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        //getall
    }
}
