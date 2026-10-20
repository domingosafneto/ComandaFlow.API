using ComandaFlow.Application.Comandas.ListarComandas;
using ComandaFlow.Application.Comandas.Queries.ObterComandaPorId;
using Microsoft.Extensions.DependencyInjection;

namespace ComandaFlow.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ListarComandasUseCase>();
        services.AddScoped<ObterComandaPorIdQueryHandler>();

        return services;
    }
}