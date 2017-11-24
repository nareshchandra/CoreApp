using AuthService.Entity;
using AuthService.Repository;
using AuthService.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace AuthService.API
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
            // Setup options with DI
            services.AddOptions();

            // Configure ConnectionStrings using config
            services.Configure<ConnectionString>(Configuration);

            // Add framework services.
            services.AddMvc();

            //Depenedency Injcetion
            services.AddSingleton<IUtility, AuthService.Utility.Utility>();
            services.AddTransient<IUnitOfWork<AuthServiceDBContext>, UnitOfWork<AuthServiceDBContext>>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V 1.0.0", new Info
                {
                    Version = "V 1.0.0",
                    Title = "Authentication Service",
                    Description = "For Authentication",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "AuthService Team", Email = "test.gmail.com", Url = "www.core.in" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
        }
    }
}
