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
        //private readonly IOperationTemplateProvider _templateProvider;

        public OperationService(IOperationRepository operationRepository, 
            IMapper mapper//,
            //IOperationTemplateProvider templateProvider
            )
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
          //  _templateProvider = templateProvider;
        }

        public async Task AddAsync(Guid accountID, Guid categoryID,string name, decimal value, OperationTypeEnum operationType)
        {
            if (accountID.Equals(new Guid()) || categoryID.Equals(new Guid()))
            {
                throw new ArgumentException("Account or category is invalid");
            }
            var operation = new Operation(accountID,
                                          categoryID, 
                                          value,
                                          name,
                                          DateTime.UtcNow,
                                          operationType
                                          );

            await _operationRepository.AddAsync(operation);
        }

        public async Task<OperationDetailsDTO> GetAsync(string name)
        {
            var operation = await _operationRepository.GetAsync(name);
            return _mapper.Map<Operation, OperationDetailsDTO>(operation);
        }

        public async Task<IList<OperationDTO>> GetAllAsync()
        {
            var operations = await _operationRepository.GetAllAsync();
            return null;
        }
    }
}
