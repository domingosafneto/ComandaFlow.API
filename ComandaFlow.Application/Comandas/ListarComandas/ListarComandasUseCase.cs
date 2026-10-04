using ComandaFlow.Domain.Entities;
using ComandaFlow.Domain.Interfaces;

namespace ComandaFlow.Application.Comandas.ListarComandas;

public class ListarComandasUseCase
{
    private readonly IComandaRepository _repository;

    public ListarComandasUseCase(
        IComandaRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Comanda>> ExecutarAsync(
        char filtro = 'T')
    {
        return _repository.ListarAsync(filtro);
    }
}