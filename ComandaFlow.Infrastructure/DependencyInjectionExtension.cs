using ComandaFlow.Domain.Interfaces;
using ComandaFlow.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ComandaFlow.Infrastructure;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string não configurada.");

        services.AddScoped<IComandaRepository>(sp =>
            new ComandaRepository(connectionString));

        return services;
    }
}