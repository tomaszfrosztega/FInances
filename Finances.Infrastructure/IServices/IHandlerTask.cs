using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface IHandlerTask
    {
        IHandlerTask Always(Func<Task> always);

        IHandlerTask OnCustomerException(Func<FinancesException, Task> onCustomError, bool propagateException = false,
            bool executeOnError = false);

        IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false,
            bool executeOnError = false);

        IHandlerTask OnSuccess(Func<Task> onSuccess);

        IHandlerTask PropagateException();

        IHandlerTask DoNotPropagateException();

        IHandler Next();

        Task ExecuteAsync();
    }
}
