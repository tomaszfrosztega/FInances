using Finances.Infrastructure.DTO;
using Finances.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    [Route("[controller]")]
    public class OperationController :Controller
    {
        private readonly IOperationServices _operationServices;

        public OperationController(IOperationServices operationServices)
        {
            _operationServices = operationServices;
        }

        [HttpGet("{name}")]
        public OperationDTO Get(string name)
            => _operationServices.Get(name);
    }
}
