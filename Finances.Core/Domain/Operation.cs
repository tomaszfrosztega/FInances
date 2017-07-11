using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain
{
    public class Operation
    {
        public Guid Id { get; protected set; }

        public Guid CategoryId { get; protected set; }

        public Guid AccountId { get; protected set; }

        public decimal Value { get; protected set; }

        public string Name { get; protected set; }

        public DateTime DateAdd { get; protected set; }

        public OperationTypeEnum OperationType { get; protected set; }

        protected Operation()
        {
        }

        public Operation(Guid categoryId, Guid accountId, decimal value, string name, DateTime dateAdd, OperationTypeEnum operationType)
        {
            Id = Guid.NewGuid();
            CategoryId = categoryId;
            AccountId = accountId;
            Value = value;
            Name = name;
            DateAdd = dateAdd;
            OperationType = operationType;
        }
    }
}
