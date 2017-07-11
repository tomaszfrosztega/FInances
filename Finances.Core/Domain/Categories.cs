﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Domain
{
    public class Categories
    {
        public Guid Id { get; protected set; }

        public Guid ParentCategoryId { get; protected set; }

        public string Name { get; protected set; }

        public OperationTypeEnum DefaultOperationType { get; protected set; }

        protected Categories()
        {

        }
        public Categories(Guid parentCategoryId, string name, OperationTypeEnum defaultOperaionType)
        {
            Id = Guid.NewGuid();
            Name = name;
            DefaultOperationType = defaultOperaionType;
        }
    }
}