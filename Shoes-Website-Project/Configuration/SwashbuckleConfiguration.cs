using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shoes_Website_Project.Configuration
{
    public static class SwashbuckleConfiguration
    {
        private const string API_VERSION = "v1.0";
        private const string API_TITLE = "Bidding Project";
        private const string END_POINT = "v1.0/swagger.json";
        private const string JSON_ROUTE = "swagger/{documentName}/swagger.json";

        public static void ConfigurationSwashbuckle(this IServiceCollection services)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc(API_VERSION, new OpenApiInfo { Title = API_TITLE, Version = API_VERSION });
            });
        }

        public static void UseSwashbuckle(this IApplicationBuilder app)
        {
            app.UseSwagger(opts =>
            {
                opts.RouteTemplate = JSON_ROUTE;
            });

            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint(END_POINT, API_TITLE);
            });
        }
    }
}
