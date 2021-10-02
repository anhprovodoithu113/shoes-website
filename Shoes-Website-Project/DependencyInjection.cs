using System;
using System.Text;
using Shoes_Website.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Shoes_Website_Project.Services;
using Shoes_Website.Domain.Intefaces;
using Hellang.Middleware.ProblemDetails;
using Shoes_Website.Application.Options;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using Hellang.Middleware.ProblemDetails.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shoes_Website_Project.Configuration.Exceptions;
using Microsoft.AspNetCore.Http.Features;
using Shoes_Website_Project.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Shoes_Website_Project
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ICacheService, CacheService>();
            services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();
            ConfigureBearer(services, configuration);
            ConfigAuthenAndAuthorize(services);
            services.AddProblemDetails(ConfigureProblemDetails)
                    .AddControllers()
                    .AddProblemDetailsConventions()
                    .AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            return services;
        }

        private static void ConfigAuthenAndAuthorize(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserRole", policyBuilder =>
                {
                    policyBuilder.RequireCustomClaim(ClaimTypes.Name);
                });

                config.AddPolicy("AdminRole", policyBuilder =>
                {
                    policyBuilder.RequireCustomClaim("Admin");
                });
            });
        }

        private static void ConfigureBearer(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = new JwtSettings();
            configuration.GetSection("JwtOptions").Bind(jwtSettings);
            services.Configure<JwtSettings>(options => configuration.GetSection("JwtOptions").Bind(options));
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                });

            services.AddScoped<ICurrentUserService, CurrentUserService>();
        }

        private static void ConfigureProblemDetails(ProblemDetailsOptions options)
        {
            options.Map<ValidationException>(ex => new ValidationProblemDetails(ex));

            options.MapToStatusCode<BusinessValidationException>(StatusCodes.Status400BadRequest);
            options.MapToStatusCode<PermissionAccessException>(StatusCodes.Status401Unauthorized);

            options.MapToStatusCode<Exception>(StatusCodes.Status500InternalServerError);
            options.MapToStatusCode<ArgumentException>(StatusCodes.Status500InternalServerError);
        }
    }
}
