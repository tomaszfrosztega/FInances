using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Core.Domain
{
    public class Tag
    {

        public string Name { get; set; }

        public Guid DefaultCategoryId { get; set; }

        protected Tag()
        {
        }

        public Tag(string name, Guid defaultCategory)
        {
            Name = name;
            DefaultCategoryId = DefaultCategoryId;
        }

        public static Tag Create(string name, Guid defaultCategoty)
            => new Tag(name, defaultCategoty);
    }
}
