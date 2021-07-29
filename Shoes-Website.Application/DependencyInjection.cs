using MediatR;
using FluentValidation;
using System.Reflection;
using Shoes_Website.Application.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shoes_Website.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CurrentUser>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
