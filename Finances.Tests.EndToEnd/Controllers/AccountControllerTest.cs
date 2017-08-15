using Finances.Infrastructure.Commands.Accounts;
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
    public class AccountControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task GivenValidNameAccountShouldExist()
        {
            var name = "RoR";
            var account = await GetOperationAsync(name);

            account.AccountName.ShouldBeEquivalentTo(name);
        }

        [Fact]
        public async Task GivenInvalidNameAccountShouldNotExist()
        {
            var name = "notexist";
            var response = await Client.GetAsync($"operation/{name}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivenValidDataOperationShouldBeCreated()
        {
            var command = new CreateAccount
            {
                Name = "InvalidAccountName",
                Value = 1000m
            };
            var payload = Payload(command);
            var response = await Client.PostAsync("account", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"account/{command.Name}");

            var user = await GetOperationAsync(command.Name);
            user.AccountName.ShouldBeEquivalentTo(command.Name);
        }

        private async Task<AccountDTO> GetOperationAsync(string name)
        {
            var response = await Client.GetAsync($"account/{name}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<AccountDTO>(responseString);
        }
    }
}
