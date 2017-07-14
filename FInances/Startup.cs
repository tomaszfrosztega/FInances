using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Finances.Infrastructure.Services;
using Finances.Core.Repositories;
using Finances.Infrastructure.Repositories;
using Finances.Infrastructure.IServices;

namespace FInances
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)//Create configuration based on file
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddScoped<IUserServices, UserService>();
            services.AddScoped<IAccountServices, AccountService>();
            services.AddScoped<IOperationServices, OperationService>();
            services.AddScoped<ICategoryServices, CategoryService>();

            services.AddScoped<IAccountRepository, InMemoryAccountRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IOperationRepository, InMemoryOperationRepository>();
            services.AddScoped<ICategoryRepository, InMemoryCategoryRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
