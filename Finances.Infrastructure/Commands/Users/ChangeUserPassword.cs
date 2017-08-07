using Finances.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Commands.Users
{
    public class ChangeUserPassword : ICommand
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
