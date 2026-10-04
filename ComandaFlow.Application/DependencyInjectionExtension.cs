using Microsoft.Extensions.DependencyInjection;
using ComandaFlow.Application.Comandas.ListarComandas;

namespace ComandaFlow.Application;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ListarComandasUseCase>();

        return services;
    }
}