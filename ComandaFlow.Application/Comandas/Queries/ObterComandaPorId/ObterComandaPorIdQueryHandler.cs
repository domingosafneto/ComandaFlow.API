
using ComandaFlow.Domain.Entities;
using ComandaFlow.Domain.Interfaces;

namespace ComandaFlow.Application.Comandas.Queries.ObterComandaPorId;

public sealed class ObterComandaPorIdQueryHandler
{
    private readonly IComandaRepository _repository;

    public ObterComandaPorIdQueryHandler(
        IComandaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Comanda?> HandleAsync(
        ObterComandaPorIdQuery query)
    {
        return await _repository.ObterPorIdAsync(query.Id);
    }
}