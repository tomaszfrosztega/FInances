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

        public DateTime OperatrionDate { get; protected set; }

        public OperationTypeEnum OperationType { get; protected set; }

        public DateTime? UpdatedAt { get; protected set; }

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
            OperatrionDate = dateAdd;
            OperationType = operationType;
        }

        /// <summary>
        /// Temporary
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Operation Create(string name, decimal value)
        {
            return new Operation
            {
                Name = name,
                Value = value
            };
        }
    }
}
