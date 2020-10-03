using BusinessLogicLayer.HelperClasses;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using DataAccessLayer;
using DataAccessLayer.Context;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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

        //users
        public static void ConfigureUserContext(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
        }

        public static void ConfigureUserRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }


        public static void ConfigurePasswordManager(this IServiceCollection services)
        {
            services.AddScoped<IPasswordManager, PasswordManager>();
        }

        public static void ConfigureJWTHandler(this IServiceCollection services)
        {
            services.AddScoped<IJWTHandler, JWTHandler>();
        }


        public static void ConfigureAuthenticationHandler(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                    ValidateIssuerSigningKey = true

                };
            });
        }

    }
}
