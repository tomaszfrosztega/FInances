using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Core.Domain
{
    public abstract class FinancesException : Exception
    {
        public string Code { get; }

        protected FinancesException()
        {

        }
        public FinancesException(string code)
        {
            Code = code;
        }

        public FinancesException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public FinancesException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public FinancesException(Exception innerException, string message, params object[] args) 
            : this(innerException, string.Empty, message, args)
        {
        }

        public FinancesException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
