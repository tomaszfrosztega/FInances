using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.DTO
{
    public class AccountDTO
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string AccountName { get; set; }
    }
}
