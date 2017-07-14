using Finances.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core.Domain;
using Finances.Core;

namespace Finances.Infrastructure.Repositories
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        private static ISet<Category> _category = new HashSet<Category>
        {
            new Category(null,"House",OperationTypeEnum.Expense,true),
            new Category(null,"Work",OperationTypeEnum.Expense,true)
        };

        public void Add(Category category)
        {
            _category.Add(category);
        }

        public void Delete(Category category)
        {
            _category.Remove(category);
        }

        public Category Get(Guid id)
            => _category.Single(x => x.Id == id);

        public Category Get(string name)
            => _category.Single(x => x.Name == name);

        public IEnumerable<Category> GetAll()
        {
            return _category;
        }

        public void Update(Category category)
        {
        }
    }
}
