using System.Diagnostics;
using Azure.Storage.Blobs;
using WebRecruitment.WebApi.Configuration;

namespace WebRecruitment.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection WebApiConfiguration(this IServiceCollection services, string secretKey)
    {
        services.SecurityConfiguration(secretKey);
        // ALLOW HTTP
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHealthChecks();

        services.AddSingleton<Stopwatch>();
        services.AddHttpContextAccessor();
        services.AddCors(option => option.AddDefaultPolicy(builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));

        services.ConfigureSwagger();
        
        
        return services;
    }
}