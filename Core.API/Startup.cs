using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entity;
using Core.Manager;
using Core.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Core.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            //Depenedency Injcetion
            //services.AddSingleton<ICommon, Common>();
            services.AddTransient<IRepository<Product>, BaseRepository<Product>>();
            services.AddTransient<IProductManager, ProductManager>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Core Rest Service",
                    Description = "The expose core functionality",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Core Team", Email = "test.gmail.com", Url = "www.core.in" }
                });
            });
            //services.ConfigureSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v2", new Info
            //    {
            //        Version = "v1",
            //        Title = "Enable Definition Core",
            //        Description = "My First ASP.NET Core Web API",
            //        TermsOfService = "None",
            //        Contact = new Contact() { Name = "JAROWA Team", Email = "Jarowa@tavant.onmicrosoft.com", Url = "www.talkingdotnet.com" }
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
        }
    }
}
