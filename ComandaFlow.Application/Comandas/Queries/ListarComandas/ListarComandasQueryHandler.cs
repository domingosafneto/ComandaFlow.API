using ComandaFlow.Domain.Entities;
using ComandaFlow.Domain.Interfaces;

namespace ComandaFlow.Application.Comandas.Queries.ListarComandas;

public sealed class ListarComandasQueryHandler
{
    private readonly IComandaRepository _repository;

    public ListarComandasQueryHandler(
        IComandaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Comanda>> HandleAsync(
        ListarComandasQuery query)
    {
        return await _repository.ListarAsync(query.Filtro);
    }
}