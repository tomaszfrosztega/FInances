using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Exceptions
{
    public class ServiceExceptions : FinancesException
    {
        protected ServiceExceptions()
        {

        }
        public ServiceExceptions(string code)
        {
        }

        public ServiceExceptions(string message, params object[] args) 
            : base(string.Empty, message, args)
        {
        }

        public ServiceExceptions(string code, string message, params object[] args) 
            : base(null, code, message, args)
        {
        }

        public ServiceExceptions(Exception innerException, string message, params object[] args) 
            : base(innerException, string.Empty, message, args)
        {
        }

        public ServiceExceptions(Exception innerException, string code, string message, params object[] args)
            : base(code, string.Format(message, args), innerException)
        {
        }
    }
}
