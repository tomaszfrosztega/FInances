using Finances.Infrastructure.IServices;
using System.Collections.Generic;
using Finances.Core;
using Finances.Infrastructure.DTO;
using Finances.Core.Repositories;
using Finances.Core.Domain;
using AutoMapper;
using System.Threading.Tasks;

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

        public async Task AddAsync(string name, OperationTypeEnum defaultOperationType)
        {
            var category = new Category(null, name, defaultOperationType, true);

            await _categoryRepository.AddAsync(category);
        }

        public async Task<CategoryDTO> GetAsync(string name)
        {
            var category = await _categoryRepository.GetAsync(name);

            return _mapper.Map<Category, CategoryDTO>(category);
        }

        public async Task<ISet<CategoryDTO>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return null;
        }
    }
}
