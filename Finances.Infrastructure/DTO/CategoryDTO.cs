using Finances.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Infrastructure.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get;  set; }

        public Guid? ParentCategoryId { get;  set; }

        public string Name { get;  set; }

        public OperationTypeEnum DefaultOperationType { get;  set; }
    }
}
