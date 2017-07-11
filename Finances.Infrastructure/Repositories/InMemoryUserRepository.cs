using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Finances.Core.Domain;
using System.Linq;

namespace Finances.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>
        {
            new User("user1@gmail.com","user","a","salt"),
            new User("user2@gmail.com","user2","a","salt")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(Guid id)
            => _users.Single(x => x.Id == id);

        public User Get(string email)
             => _users.Single(x => x.Email == email.ToLowerInvariant());

        public void Update(User user)
        {
        }
    }
}
