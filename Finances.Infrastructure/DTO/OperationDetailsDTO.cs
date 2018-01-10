using Finances.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.DTO
{
    public class OperationDetailsDTO : OperationDTO
    {
        public IEnumerable<TagDTO> Tags { get; set; }
    }
}
