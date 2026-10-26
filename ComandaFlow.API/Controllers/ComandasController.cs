
using Microsoft.AspNetCore.Mvc;
using ComandaFlow.Application.Common.Messages;
using ComandaFlow.Application.Comandas.Queries.ListarComandas;
using ComandaFlow.Application.Comandas.Queries.ObterComandaPorId;

namespace ComandaFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComandasController : ControllerBase
{
    private readonly ListarComandasQueryHandler _listarHandler;
    private readonly ObterComandaPorIdQueryHandler _obterPorIdHandler;

    public ComandasController(
        ListarComandasQueryHandler listarHandler,
        ObterComandaPorIdQueryHandler obterPorIdHandler)
    {
        _listarHandler = listarHandler;
        _obterPorIdHandler = obterPorIdHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] char filtro = 'T')
    {
        var query = new ListarComandasQuery(filtro);

        var comandas = await _listarHandler.HandleAsync(query);

        return Ok(comandas);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> ObterPorId([FromRoute] long id)
    {
        var query = new ObterComandaPorIdQuery(id);

        var comanda = await _obterPorIdHandler.HandleAsync(query);

        if (comanda is null)
        {
            return NotFound(new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = Mensagens.Alerta.ComandaNaoEncontrada
            });
        }

        return Ok(comanda);
    }
}