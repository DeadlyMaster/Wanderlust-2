using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wanderlust.Services.API.Models;

namespace Wanderlust.Services.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //DbContextOptions<DbContext> contextOptions = new DbContextOptionsBuilder<DbContext>().UseInMemoryDatabase("Context").Options; services.AddSingleton(contextOptions);

            //var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //build in dependency injection of ASP.NET core

            //services.AddSingleton<ILandmarkRepository, LandmarkRepository>(); // error creating the migration
            //services.AddSingleton<ILandmarkService, LandmarkService>();

            services.AddScoped<ILandmarkRepository, LandmarkRepository>();
            services.AddScoped<IJourneyRepository, JourneyRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); 
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseMvcWithDefaultRoute();
            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
