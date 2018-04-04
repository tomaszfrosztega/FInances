using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Operations;
using Finances.Infrastructure.DTO;
using Finances.Infrastructure.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Api.Controllers
{
    public class OperationController : ApiBaseController
    {
        private readonly IOperationServices _operationServices;

        public OperationController(IOperationServices operationServices, ICommandDispatcher commandDispatcher)
            :base(commandDispatcher)
        {
            _operationServices = operationServices;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var operation = await _operationServices.GetAsync(name);
            if (operation == null)
            {
                return NotFound();
            }
            return Json(operation);
        }

        //[HttpGet]
        //[Route("{operationId}")]
        //public async Task<IActionResult> GetAsync(Guid operationId)
        //{
        //    var operation = await _operationServices.GetAsync(name);
        //    if (operation == null)
        //    {
        //        return NotFound();
        //    }
        //    return Json(operation);
        //}

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOperation command)
        {
            await DispatchAsync(command);

            return Created($"operation/{command.Name}", null);
        }

       // [Authorize]
        [HttpPut("{name}")]
        public async Task<IActionResult> Put([FromBody] UpdateOperation command)
        {
            await DispatchAsync(command);

            return NoContent();
        }

      //  [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> Post()
        {
            await DispatchAsync(new DeleteOperation());

            return NoContent();
        }

    }
}
