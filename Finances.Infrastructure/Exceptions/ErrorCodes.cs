using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Exceptions
{
    public static class ErrorCodes
    {
        public static string InvalidUserName => "invalid_username";
        public static string InvalidEmail => "invalid_email";
        public static string EmailInUse => "emails_inuse";
        public static string InvalidCredentials => "invalid_credentials";
        public static string UserNotFound => "user_not_found";
        public static string EmailAlreadyExist => "user_with_email_already_exist";
    }
}