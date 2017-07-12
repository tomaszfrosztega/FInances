using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain
{
    public class Account
    {
        public Guid Id { get; protected set; }

        public decimal Amount { get; protected set; }

        public string AccountName { get; protected set; }

        public DateTime CreatedDate { get; protected set; }

        public DateTime UpdatedAt { get; protected set; }

        protected Account()
        {
        }

        public Account(decimal amount, string accountName)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            AccountName = accountName;
            CreatedDate = DateTime.UtcNow;
        }
    }
}
