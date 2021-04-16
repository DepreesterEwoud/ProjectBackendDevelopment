using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjectBackendDevelopment.Config;
using ProjectBackendDevelopment.DataContext;
using ProjectBackendDevelopment.Repositories;
using ProjectBackendDevelopment.Services;

namespace ProjectBackendDevelopment
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
            services.AddAutoMapper(typeof(Startup));

            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddDbContext<SponsorContext>();

            services.AddControllers();
            services.AddTransient<ISponsorContext,SponsorContext>();
            services.AddTransient<IPlayerRepository,PlayerRepository>();
            services.AddTransient<ISponsorRepository,SponsorRepository>();
            services.AddTransient<ITeamRepository,TeamRepository>();
            services.AddTransient<IRugNummerRepository,RugNummerRepository>();

            services.AddTransient<ISponsorService,SponsorService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectBackendDevelopment", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjectBackendDevelopment v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
