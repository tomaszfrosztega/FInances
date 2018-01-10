using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Categories;
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
    public class CategoryController : ApiBaseController
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices, ICommandDispatcher commandDispatcher)
            :base(commandDispatcher)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAsync(string name)
        {
            var category = await _categoryServices.GetAsync(name);
            if (category == null)
            {
                return NotFound();
            }

            return Json(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategory command)
        {
            await DispatchAsync(command);

            return Created($"category/{command.Name}", null);
        }
    }
}
