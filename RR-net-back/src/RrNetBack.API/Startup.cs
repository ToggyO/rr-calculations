using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RrNetBack.API.Extensions;
using RrNetBack.API.Filters;
using RrNetBack.BLL.Mappings;
using RrNetBack.Common.Settings;
using RrNetBack.DAL;
// TODO: add exception middleware
namespace RrNetBack.API
{
    public class Startup
    {
        private const string MyAllowOrigins = "_myAllowOrigins";

        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowOrigins,
                    builder => builder
                        // .SetIsOriginAllowed(origin => true)
                        // .WithOrigins("http://185.227.108.172")
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        // .AllowCredentials()
                );
            });

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            var dbSettings = new DbSettings
            {
                DB_HOST = Configuration.GetSection("DB_HOST").Value,
                DB_PORT = Configuration.GetSection("DB_PORT").Value,
                DB_USER = Configuration.GetSection("DB_USER").Value,
                DB_PASSWORD = Configuration.GetSection("DB_PASSWORD").Value,
                DB_NAME = Configuration.GetSection("DB_NAME").Value,
            };

            services.AddDbContext<ApplicationDbContext>(options => 
                options
                    .EnableSensitiveDataLogging()
                    .UseNpgsql(dbSettings.DbConnectionString,
                        builder =>
                            builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ValidateModelAttribute));
                options.Filters.Add(typeof(StatusCodeFilter));
            }).AddFluentValidation(
                fv =>
                    fv.RegisterValidatorsFromAssemblyContaining<DTO.DependencyInjectionModule>());

            services.AddSingleton(MappingConfig.GetMapper());
			
            DependencyInjectionModule.Load(services);
        }

        public void Configure(IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger<Startup> logger)
        {
            logger.LogInformation("Enter Configure");
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            logger.LogInformation("Routing");
            app.UseRouting();
            
            logger.LogInformation("Middleware");

            logger.LogInformation("Cors");
            app.UseCors(MyAllowOrigins);

            logger.LogInformation("EnsureMigrationOfContext");
            app.EnsureMigrationContext<ApplicationDbContext>();

            logger.LogInformation("Endpoints");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            logger.LogInformation("Exit Configure");
        }
    }
}
