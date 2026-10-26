
using Microsoft.Extensions.DependencyInjection;
using ComandaFlow.Application.Comandas.Queries.ListarComandas;
using ComandaFlow.Application.Comandas.Queries.ObterComandaPorId;

namespace ComandaFlow.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<ListarComandasQueryHandler>();
        services.AddScoped<ObterComandaPorIdQueryHandler>();

        return services;
    }
}