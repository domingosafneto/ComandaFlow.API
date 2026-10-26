using ComandaFlow.Domain.Interfaces;
using ComandaFlow.Infrastructure.Common.Messages;
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
            ?? throw new InvalidOperationException(MensagensInfra.ConexaoNaoConfigurada);

        services.AddScoped<IComandaRepository>(sp => new ComandaRepository(connectionString));

        return services;
    }
}