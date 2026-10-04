using ComandaFlow.Domain.Entities;
using ComandaFlow.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ComandaFlow.Infrastructure.Repositories;

public class ComandaRepository : IComandaRepository
{

    private readonly string _connectionString;

    public ComandaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Comanda>> ListarAsync(char filtro = 'T')
    {
        using var connection = new SqlConnection(_connectionString);

        var parametros = new DynamicParameters();
        parametros.Add("@Filtro", filtro.ToString());

        return await connection.QueryAsync<Comanda>(
            "dbo.pr_ListarComandas",
            parametros,
            commandType: CommandType.StoredProcedure
        );
    }
}