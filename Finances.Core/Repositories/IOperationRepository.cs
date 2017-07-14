using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Repositories
{
    public interface IOperationRepository
    {
        Operation Get(Guid id);

        Operation Get(string name);

        IEnumerable<Operation> GetAll();

        void Add(Operation operation);

        void Update(Operation operation);

        void Delete(Operation operation);

    }
}
