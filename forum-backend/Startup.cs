using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using forum_backend.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace forum_backend
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
            services.ConfigureDatabase();
            services.ConfigureCors();
            //containers
            services.ConfigureContainerContext();
            services.ConfigureContainerRepository();
            //sections
            services.ConfigureSectionContext();
            services.ConfigureSectionRepository();
            //categories
            services.ConfigureCategoryContext();
            services.ConfigureCategoryRepository();
            //topics
            services.ConfigureTopicContext();
            services.ConfigureTopicRepository();

            //add controllers
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

            app.Use(async (context, nextMiddleware) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("Cache-Control", "no-cache, no-store");
                    context.Response.Headers.Add("Expires", "-1");
                    return Task.FromResult(0);
                });
                await nextMiddleware();
            });

            app.UseCors("CorsDevelopment"); ;

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors("CorsDevelopment");
            });
        }
    }
}
