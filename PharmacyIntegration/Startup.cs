using Backend.Medications.Repository.FileRepository;
using Backend.Medications.Repository.MySqlRepository;
using Backend.Medications.Service;
using Backend.Pharmacies.Repository.MySqlRepository;
using Backend.Reports.Repository;
using Backend.Reports.Repository.MySqlRepository;
using Backend.Reports.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Model;
using PharmacyIntegration.Repository;
using PharmacyIntegration.Service;
using System;
using System.Reflection;

namespace PharmacyIntegration
{
    public class Startup
    {
        public Startup ( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices ( IServiceCollection services )
        {
            services.AddDbContext<MySqlContext>();

            services.AddTransient<IPharmacyRepository, PharmacySqlRepository>();
            services.AddTransient<IPharmacyNotificationRepository, PharmacyNotificationSqlRepository>();
            services.AddTransient<IMedicationUsageRepository, MedicationUsageSqlRepository>();
            services.AddTransient<IMedicationUsageReportRepository, MedicationUsageReportSqlRepository>();

            services.AddScoped<IPharmacyService, PharmacyService>();
            services.AddScoped<IPharmacyNotificationService, PharmacyNotificationService>();
            services.AddScoped<IMedicationUsageService, MedicationUsageService>();
            services.AddScoped<IMedicationUsageReportService, MedicationUsageReportService>();

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSpaStaticFiles(options => options.RootPath = "vueclient/dist");

            services.AddDbContext<MySqlContext>();

            services.AddDbContext<MySqlContext>(options =>
                 options.UseMySql(CreateConnectionStringFromEnvironment()));

            services.AddScoped<MySqlContext>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure ( IApplicationBuilder app, IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // add following statements
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";
                if ( env.IsDevelopment() )
                {
                    // Launch development server for Vue.js
                    spa.UseVueDevelopmentServer();
                }
            });
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)); // allow any origin


            if (!IsLocalServer())
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<MySqlContext>();

                    RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>();
                    if (!databaseCreator.HasTables())
                        databaseCreator.CreateTables();
                }
            }
        }

        private string CreateConnectionStringFromEnvironment ( )
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "newdb";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";
            ;
        }

        private bool IsLocalServer()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            return server.Equals("localhost");
        }
    }
}