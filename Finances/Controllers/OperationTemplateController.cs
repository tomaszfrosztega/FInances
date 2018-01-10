using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.Commands;
using Finances.Infrastructure.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Finances.Api.Controllers
{
    public class OperationTemplateController : ApiBaseController
    {
        private readonly IOperationTemplateProvider _templateProvider;

        public OperationTemplateController(ICommandDispatcher commandDispatcher,
            IOperationTemplateProvider templateProvider) : base(commandDispatcher)
        {
            _templateProvider = templateProvider;
        }

        public async Task<IActionResult> Get()
        {
            var operationTemplates = await _templateProvider.BrowseAsync();

            return Json(operationTemplates);
        }
    }
}
