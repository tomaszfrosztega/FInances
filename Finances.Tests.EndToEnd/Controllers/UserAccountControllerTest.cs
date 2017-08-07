using Finances.Infrastructure.Commands.Users;
using FInances;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Finances.Tests.EndToEnd.Controllers
{
    public class UserAccountControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task GivenValidCurrentAndNewPasswordItShouldBeChanged()
        {
            var command = new ChangeUserPassword
            {
                OldPassword = "secret",
                NewPassword = "new"
            };

            var payload = Payload(command);
            var response = await Client.PutAsync("useraccount/password", payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NoContent);
        }

    }
}
