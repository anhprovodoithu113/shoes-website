using Microsoft.Extensions.DependencyInjection;

namespace Shoes_Website_Project.Configuration
{
    public static class CorsConfigurations
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opts =>
                opts.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .WithExposedHeaders("*")));
        }
    }
}
