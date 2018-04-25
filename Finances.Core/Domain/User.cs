using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Finances.Core.Domain
{
    public class User
    {
        private static readonly Regex _userNameValidator = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public Guid Id { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public string Salt { get; protected set; }

        public string UserName { get; protected set; }

        public string FullName { get; protected set; }

        public string Role { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(Guid userId,string email, string username, string password, string salt)
        {
            Id = userId;
            Email = email.ToLowerInvariant();
            UserName = username;
            Password = password;
            Salt = salt;
            CreatedDate = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Role = "admin";
        }

        public void SetUserName(string username)
        {
            if (!_userNameValidator.IsMatch(username))
            {
                throw new DomainException(ErrorCodes.InvalidUserName, "Inproper user name");
            }
            UserName = username;
        }

    }

}
