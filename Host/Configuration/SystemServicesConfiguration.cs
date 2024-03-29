﻿using Application.Services;
using Core.Interfaces.Services;
using FluentValidation.AspNetCore;
using WebApi.Validators.CategoryValidators;

namespace BookCrossingBackEnd.Configuration;

public static class SystemServicesConfiguration
{
    public const string AllowedOrigins = "frontend";

    public static void AddSystemServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddTransient<ILoggerManager, LoggerManager>();
        services.AddMemoryCache();
        
        services.AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<UpdateCategoryValidator>();
        });

        services.AddHttpClient();

        services.AddCors(options =>
        {
            options.AddPolicy(name: AllowedOrigins,
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200");
                    policy.WithHeaders("*");
                    policy.WithMethods("*");
                    policy.AllowCredentials();
                    policy.WithExposedHeaders("X-Pagination");
                });
        });
    }
}