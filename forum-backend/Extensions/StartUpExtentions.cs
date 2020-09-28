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

        //containers
        public static void ConfigureContainerContext(this IServiceCollection services)
        {
            services.AddScoped<IContainerContext, ContainerContext>();
        }

        public static void ConfigureContainerRepository(this IServiceCollection services)
        {
            services.AddScoped<IContainerRepository, ContainerRepository>();
        }

        //sections
        public static void ConfigureSectionContext(this IServiceCollection services)
        {
            services.AddScoped<ISectionContext, SectionContext>();
        }

        public static void ConfigureSectionRepository(this IServiceCollection services)
        {
            services.AddScoped<ISectionRepository, SectionRepository>();
        }

        //categories
        public static void ConfigureCategoryContext(this IServiceCollection services)
        {
            services.AddScoped<ICategoryContext, CategoryContext>();
        }

        public static void ConfigureCategoryRepository(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        //topics
        public static void ConfigureTopicContext(this IServiceCollection services)
        {
            services.AddScoped<ITopicContext, TopicContext>();
        }

        public static void ConfigureTopicRepository(this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
        }

    }
}
