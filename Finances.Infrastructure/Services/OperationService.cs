using Finances.Core.Repositories;
using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.DTO;
using Finances.Core.Domain;
using Finances.Core;
using AutoMapper;

namespace Finances.Infrastructure.Services
{
    public class OperationService :IOperationServices
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;

        public OperationService(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(string name, decimal value)
        {
            var operation = new Operation(new Guid(), 
                                          new Guid(), 
                                          value,
                                          name,
                                          DateTime.UtcNow, 
                                          OperationTypeEnum.Expense
                                          );

            await _operationRepository.AddAsync(operation);
        }

        public async Task<OperationDTO> GetAsync(string name)
        {
            var operation = await _operationRepository.GetAsync(name);

            return _mapper.Map<Operation, OperationDTO>(operation);
        }

        public async Task<IList<OperationDTO>> GetAllAsync()
        {
            var operations = await _operationRepository.GetAllAsync();
            return null;
        }
    }
}
