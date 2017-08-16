using Finances.Core;
using System;

namespace Finances.Infrastructure.Commands.Operations
{
    public class CreateOperation : ICommand
    {
        public Guid AccountID { get; set; }

        public Guid CategoryID { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }

        public OperationTypeEnum OperationType { get; set; }
    }
}
