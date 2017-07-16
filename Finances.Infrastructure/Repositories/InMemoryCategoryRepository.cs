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

        public async Task AddAsync(Category category)
        {
            _category.Add(category);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Category category)
        {
            _category.Remove(category);
            await Task.CompletedTask;
        }

        public async Task<Category> GetAsync(Guid id)
            => await Task.FromResult(_category.SingleOrDefault(x => x.Id == id));

        public async Task<Category> GetAsync(string name)
            => await Task.FromResult(_category.SingleOrDefault(x => x.Name == name));

        public async Task<ISet<Category>> GetAllAsync()
        {
            return await Task.FromResult(_category);
        }

        public async Task UpdateAsync(Category category)
        {
            await Task.CompletedTask;
        }
    }
}
