using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnDockerCompose.Contract;
using LearnDockerCompose.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LearnDockerCompose
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
            services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Color API", Version = "v1" });

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            var swaggerOptions = new SwaggerOptions();

            Configuration.GetSection(nameof(swaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(opt => opt.RouteTemplate = swaggerOptions.JsonRoute);

            app.UseSwaggerUI(opt => opt.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
