using ComandaFlow.Domain.Entities;

namespace ComandaFlow.Domain.Interfaces;

public interface IComandaRepository
{
    Task<IEnumerable<Comanda>> ListarAsync(char filtro = 'T');
}