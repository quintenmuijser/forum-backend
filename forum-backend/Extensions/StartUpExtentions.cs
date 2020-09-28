using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using DataAccessLayer;
using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum_backend.Extensions
{
    public static class StartupExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsDevelopment", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddTransient<IDatabase, Database>();
        }

        public static void ConfigureContainerContext(this IServiceCollection services)
        {
            services.AddScoped<IContainerContext, ContainerContext>();
        }

        public static void ConfigureContainerRepository(this IServiceCollection services)
        {
            services.AddScoped<IContainerRepository, ContainerRepository>();
        }


 
        

    }
}
