using Finances.Infrastructure.Commands.Users;
using Finances.Infrastructure.DTO;
using FInances;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
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
    public class UserControllerTest : ControllerTestBase
    {
        [Fact]
        public async Task GivenValidEmailUserShouldExist()
        {
            var email = "user1@gmail.com";
            var user = await GetUserAsync(email);

            user.Email.ShouldBeEquivalentTo(email);
        }

        [Fact]
        public async Task GivenInValidEmailUserShouldNotExist()
        {
            var email = "user199@gmail.com";
            var response = await Client.GetAsync($"user/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivenValidEmailUserShouldBeCreated()
        {
            var command = new CreateUser
            {
                Email = "test@gmail.com",
                Password = "a",
                UserName = "Test"
            };
            var payload = Payload(command);
            var response = await Client.PostAsync("user",payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"user/{command.Email}");

            var user = await GetUserAsync(command.Email);
            user.Email.ShouldBeEquivalentTo(command.Email);
        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"user/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }

    }
}
