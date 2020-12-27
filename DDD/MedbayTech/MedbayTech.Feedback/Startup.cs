using System;
using MedbayTech.Feedback.Application.Common.Interfaces.Gateways;
using MedbayTech.Feedback.Infrastructure.Database;
using MedbayTech.Feedback.Infrastructure.Gateways;
using MedbayTech.Feedback.Infrastructure.Persistance;
using MedbayTech.Feedback.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace MedbayTech.Feedback
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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<FeedbackDbContext>();

            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IUserGateway, UserGateway>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            using (var scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<FeedbackDbContext>())
            {
                try
                {
                    FeedbackDataSeeder seeder = new FeedbackDataSeeder();
                    if(!seeder.IsAlreadyFull(context))
                        seeder.SeedAllEntities(context);

                }
                catch (Exception)
                {
                    Console.WriteLine("Failed to seed data");
                }
            }
        }


    }
}
