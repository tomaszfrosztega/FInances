using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core;

namespace Finances.Infrastructure.Commands.Categories
{
    public class CreateCategory
    {
        public string Name { get; set; }

        public OperationTypeEnum DefaultOperationType { get; set; }
    }
}
