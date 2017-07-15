using Finances.Core.Domain;
using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Finances.Infrastructure.DTO;
using AutoMapper;

namespace Finances.Infrastructure.Services
{
    public class UserService : IUserServices
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDTO Get(string email)
        {
            var user = _userRepository.Get(email);
            
            return _mapper.Map<User,UserDTO>(user);
        }

        public void Register(string email, string username, string password)
        {
            var salt = Guid.NewGuid().ToString("N");
            var user = new User(email,username,password,salt);
            _userRepository.Add(user);
        }
    }
}
