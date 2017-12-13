using Finances.Infrastructure.IServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Services
{
    public class DataInitializer : IDataInitializer
    {
        private readonly IUserServices _userService;
        private readonly ILogger<DataInitializer> _logger;

        public DataInitializer(IUserServices userService, ILogger<DataInitializer> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        public async Task SeedAsync()
        {
            _logger.LogTrace("Initializing data...");
            _logger.LogCritical("critikal");
            var tasks = new List<Task>();
            for (int i = 1; i < 11; i++)
            {
                var userId = Guid.NewGuid();
                var userName = $"user{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{userName}@gmail.com", userName, "password"));
            }
            for (int i = 1; i < 4; i++)
            {
                var userId = Guid.NewGuid();
                var userName = $"admin{i}";
                tasks.Add(_userService.RegisterAsync(userId, $"{userName}@gmail.com", userName, "password"));
            }
            await Task.WhenAll(tasks);
            _logger.LogTrace("Data was initialized");
        }
    }
}
