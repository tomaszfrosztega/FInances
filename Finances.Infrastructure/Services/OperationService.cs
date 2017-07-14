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

namespace Finances.Infrastructure.Services
{
    public class OperationService :IOperationServices
    {
        private readonly IOperationRepository _operationRepository;

        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }

        public void Add(string name, decimal value)
        {
            var operation = new Operation(new Guid(), 
                                          new Guid(), 
                                          value,
                                          name,
                                          DateTime.UtcNow, 
                                          OperationTypeEnum.Expense
                                          );

            _operationRepository.Add(operation);
        }

        public OperationDTO Get(string name)
        {
            var operation = _operationRepository.Get(name);

            var operationDTO = new OperationDTO
            {
                AccountId = operation.AccountId,
                CategoryId = operation.CategoryId,
                Id = operation.Id,
                Name = operation.Name,
                OperationType = operation.OperationType,
                Value = operation.Value
            };
            return operationDTO;
        }

        public IList<OperationDTO> GetAll()
        {
            return null;
        }
    }
}
