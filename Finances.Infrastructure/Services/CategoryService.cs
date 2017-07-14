using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Core;
using Finances.Infrastructure.DTO;
using Finances.Core.Repositories;
using Finances.Core.Domain;

namespace Finances.Infrastructure.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(string name, OperationTypeEnum defaultOperationType)
        {
            var category = new Category(null, name, defaultOperationType, true);

            _categoryRepository.Add(category);
        }

        public CategoryDTO Get(string name)
        {
            var category = _categoryRepository.Get(name);

            var categoryDTO = new CategoryDTO
            {
                DefaultOperationType = category.DefaultOperationType,
                Id = category.Id,
                Name = category.Name,
                ParentCategoryId = category.ParentCategoryId
            };

            return categoryDTO;
        }

        public ISet<CategoryDTO> GetAll()
        {
            return null;
        }
    }
}
