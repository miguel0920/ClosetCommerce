using Catalog.Persistence.Database;
using Catalog.Service.Queries.Contracts;
using Catalog.Service.Queries.Interfaces;
using Common.Logging;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Catalog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsHistoryTable("_EFMigrationsHistory", "Catalog"))
            );
            services.AddMediatR(Assembly.Load("Catalog.Service.EventHandlers"));

            services.AddTransient<IProductQueryService, ProductQueryService>();

            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddDbContextCheck<ApplicationDbContext>();

            services.AddHealthChecksUI(setup => setup.DisableDatabaseMigrations())
                .AddInMemoryStorage();

            services.AddControllers();

            // Add Authentication
            var secretKey = Encoding.ASCII.GetBytes(
                Configuration.GetValue<string>("SecretKey")
            );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                loggerFactory.AddSyslog(
                    Configuration.GetValue<string>("Papertrail:host"),
                    Configuration.GetValue<int>("Papertrail:port"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            //app.UseHealthChecksUI()

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                    ResultStatusCodes = {
                        [HealthStatus.Healthy] = StatusCodes.Status200OK,
                        [HealthStatus.Degraded] = StatusCodes.Status200OK,
                        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                    }
                });

                endpoints.MapHealthChecksUI();

                endpoints.MapControllers();
            });
        }
    }
}