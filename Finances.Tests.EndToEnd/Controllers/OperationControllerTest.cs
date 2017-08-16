using Finances.Core;
using Finances.Infrastructure.Commands.Operations;
using Finances.Infrastructure.DTO;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Finances.Tests.EndToEnd.Controllers
{
    public class OperationControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task GivenValidNameOperationShouldExist()
        {
            var name = "Two";
            var operation = await GetOperationAsync(name);

            operation.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public async Task GivenInvalidNameOperationShouldNotExist()
        {
            var name = "notexist";
            var response = await Client.GetAsync($"operation/{name}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivenValidDataOperationShouldBeCreated()
        {
            var command = new CreateOperation
            {
                AccountID = Guid.NewGuid(),
                CategoryID = Guid.NewGuid(),
                Name = "three",
                Value= 10m,
                OperationType = OperationTypeEnum.Expense
            };
            var payload = Payload(command);
            var response = await Client.PostAsync("operation", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"operation/{command.Name}");

            var operation = await GetOperationAsync(command.Name);
            operation.Name.ShouldBeEquivalentTo(command.Name);
        }

        private async Task<OperationDTO> GetOperationAsync(string name)
        {
            var response = await Client.GetAsync($"operation/{name}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<OperationDTO>(responseString);
        }
    }
}
