using Finances.Core;
using Finances.Infrastructure.Commands.Categories;
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
    public class CategoryControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task GivenValidNameCategoryShouldExist()
        {
            var name = "Work";
            var category = await GetCategoryAsync(name);

            category.Name.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public async Task GivenInvalidNameCategoryShouldNotExist()
        {
            var name = "InvalidCategoryName";
            var response = await Client.GetAsync($"category/{name}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivenValidNameCategoryShouldBeCreated()
        {
            var command = new CreateCategory
            {
                Name = "Books",
                DefaultOperationType = OperationTypeEnum.Expense
            };
            var payload = Payload(command);
            var response = await Client.PostAsync("category", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"category/{command.Name}");

            var user = await GetCategoryAsync(command.Name);
            user.Name.ShouldBeEquivalentTo(command.Name);
        }

        private async Task<CategoryDTO> GetCategoryAsync(string name)
        {
            var response = await Client.GetAsync($"category/{name}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CategoryDTO>(responseString);
        }
    }
}
