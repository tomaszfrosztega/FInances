using Finances.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(Guid id);

        Task<Category> GetAsync(string name);

        Task<ISet<Category>> GetAllAsync();

        Task AddAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(Category category);

    }
}
