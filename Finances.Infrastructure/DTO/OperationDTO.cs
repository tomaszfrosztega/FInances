using Finances.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.DTO
{
    public class OperationDTO
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get;  set; }

        public Guid AccountId { get;  set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public OperationTypeEnum OperationType { get;  set; }

    }
}
