using Finances.Infrastructure.Commands;
using Finances.Infrastructure.Commands.Categories;
using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Handlers.Categories
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private readonly ICategoryServices _categoryServices;

        public CreateCategoryHandler(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public async Task HandleAsync(CreateCategory command)
        {
            await _categoryServices.AddAsync(command.Name,command.DefaultOperationType);
        }
    }
}
