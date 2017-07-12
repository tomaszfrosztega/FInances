using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Repositories
{
    public interface ICategoryRepository
    {
        Category Get(Guid id);

        IEnumerable<Category> GetAll();

        void Add(Category category);

        void Update(Category category);

        void Delete(Category category);
    }
}
