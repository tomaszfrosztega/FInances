using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.EF
{
    public class SqlSettings
    {
        public string ConnectionString { get; set; }

        public bool InMemory { get; set; }
    }
}
