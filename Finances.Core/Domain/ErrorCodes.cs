using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Core.Domain
{
    public static class ErrorCodes
    {
        public static string InvalidUserName => "invalid_username";
        public static string InvalidEmail => "invalid_email";
        public static string InvalidRow => "invalid_row";
        public static string InvalidPassword => "invalid_password";
    }
}
