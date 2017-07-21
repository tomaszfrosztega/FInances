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
    public class UserControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserControllerTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

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
            var response = await _client.GetAsync($"user/{email}");
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivenValidEmailUserShouldBeCreated()
        {
            var request = new CreateUser
            {
                Email = "test@gmail.com",
                Password = "a",
                UserName = "Test"
            };
            var payload = Payload(request);
            var response = await _client.PostAsync("user",payload);
            response.StatusCode.ShouldBeEquivalentTo(HttpStatusCode.Created);
            response.Headers.Location.ToString().ShouldBeEquivalentTo($"user/{request.Email}");

            var user = await GetUserAsync(request.Email);
            user.Email.ShouldBeEquivalentTo(request.Email);

        }

        private async Task<UserDTO> GetUserAsync(string email)
        {
            var response = await _client.GetAsync($"user/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDTO>(responseString);
        }

        private static StringContent Payload(object data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json,Encoding.UTF8,"application/json");
        }
    }
}
