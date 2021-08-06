using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shoes_Website.Domain.Intefaces;
using Shoes_Website.Infrastructure.AuthorizationServices;
using Shoes_Website.Infrastructure.Domain;
using System;

namespace Shoes_Website.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDBContext(services, configuration);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWorkUser, UnitOfWorkUser>();
            services.AddScoped<IRepository, EFRepository>();

            return services;
        }

        private static void AddDBContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("Shoes-Website-User"));
            });

            services.AddDbContext<ShoesWebsiteDbContext>(opts =>
            {
                opts.UseSqlServer(configuration.GetConnectionString("Shoes-Website"));
            });
        }
    }
}
