using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.DTO
{
    public class TagDTO
    {
        public string Name { get; set; }

        public Guid DefaultCategoryId { get; set; }
    }
}
