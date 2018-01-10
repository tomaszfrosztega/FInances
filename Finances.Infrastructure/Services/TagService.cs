using AutoMapper;
using Finances.Core.Domain;
using Finances.Core.Repositories;
using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categotyRepository;
        private readonly IOperationRepository _operationRepository;

        public TagService(IMapper mapper,
            ICategoryRepository categoryRepository,
            IOperationRepository operationRepository)
        {
            _mapper = mapper;
            _categotyRepository = categoryRepository;
            _operationRepository = operationRepository;
        }
        public async Task AddAsync(string name, Guid categoryId, string operationName)
        {
            var category = await _categotyRepository.GetAsync(categoryId);
            //TODO: FIX :D

            //if (category == null)
            //{
            //    throw new Exception($"Category {categoryId} doesnt exist");
            //}
            var operation = await _operationRepository.GetAsync(operationName);
            if (operation == null)
            {
                throw new Exception($"Operation {operationName} doesnt exist");
            }
            var tag = new Tag(name, categoryId);
            operation.AddTag(tag);
            await _operationRepository.UpdateAsync(operation);
        }
    }
}
