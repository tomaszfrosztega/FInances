using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public class HandlerTaskRunner : IHandlerTaskRunner
    {
        private readonly ISet<IHandlerTask> _handlerTasks = new HashSet<IHandlerTask>();

        private readonly IHandler _handler;

        private readonly Func<Task> _validate;

        public HandlerTaskRunner(IHandler handler, Func<Task> validate, ISet<IHandlerTask> handlerTasks)
        {
            _handler = handler;
            _validate = validate;
            _handlerTasks = handlerTasks;
        }

        public IHandlerTask Run(Func<Task> run)
        {
            var handlerTask = new HandlerTask(_handler, run);
            _handlerTasks.Add(handlerTask);

            return handlerTask;
        }
    }
}
