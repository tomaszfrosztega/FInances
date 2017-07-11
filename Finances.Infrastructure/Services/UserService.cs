using Finances.Core.Domain;
using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Finances.Infrastructure.DTO;

namespace Finances.Infrastructure.Services
{
    public class UserService : IUserServices
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO Get(string email)
        {
            var user = _userRepository.Get(email);

            var userDto = new UserDTO {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                UserName = user.UserName
            };

            return userDto;
        }

        public void Register(string email, string username, string password)
        {
            var salt = Guid.NewGuid().ToString("N");
            var user = new User(email,username,password,salt);
            _userRepository.Add(user);
        }
    }
}
