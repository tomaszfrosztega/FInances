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
using AutoMapper;

namespace Finances.Infrastructure.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Add(string name, OperationTypeEnum defaultOperationType)
        {
            var category = new Category(null, name, defaultOperationType, true);

            _categoryRepository.Add(category);
        }

        public CategoryDTO Get(string name)
        {
            var category = _categoryRepository.Get(name);

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public ISet<CategoryDTO> GetAll()
        {
            return null;
        }
    }
}
