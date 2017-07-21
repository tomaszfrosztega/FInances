﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Commands.Accounts
{
    public class CreateAccount
    {
        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}