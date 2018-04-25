using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Finances.Infrastructure.Services;
using Finances.Core.Repositories;
using Finances.Infrastructure.Repositories;
using Finances.Infrastructure.IServices;
using Finances.Infrastructure.Mappers;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Finances.Infrastructure.IoC.Modules;
using Finances.Infrastructure.IoC;
using Microsoft.IdentityModel.Tokens;
using Finances.Infrastructure.Settings;
using System.Text;
using Newtonsoft.Json;
using Finances.Api.Framework;
using NLog.Extensions.Logging;
using NLog.Web;

namespace FInances
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)//Create configuration based on file
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            services.AddMemoryCache();
            services.AddMvc()
                .AddJsonOptions(x=>x.SerializerSettings.Formatting = Formatting.Indented);
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory, 
            IApplicationLifetime appLifeTime)
        {
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("nlog.config");

            var jwtSettings = app.ApplicationServices.GetService<JwtSettings>();

            //authentication witn jwt
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                AutomaticAuthenticate = true,

                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                }
            });
            //initializa data using CustomDataInitializer
            var generalSettings = app.ApplicationServices.GetService<GeneralSettings>();
            if (generalSettings.SeedData)
            {
                var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
                dataInitializer.SeedAsync();
            }
            app.UseCustomExceptionHandler();
            app.UseMvc();
            appLifeTime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
        }
    }
}
