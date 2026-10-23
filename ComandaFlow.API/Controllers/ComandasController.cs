
using ComandaFlow.Application.Comandas.ListarComandas;
using ComandaFlow.Application.Comandas.Queries.ObterComandaPorId;
using ComandaFlow.Application.Common.Messages;
using Microsoft.AspNetCore.Mvc;

namespace ComandaFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComandasController : ControllerBase
{
    private readonly ListarComandasUseCase _useCase;
    private readonly ObterComandaPorIdQueryHandler _obterPorIdHandler;

    public ComandasController(
        ListarComandasUseCase useCase,
        ObterComandaPorIdQueryHandler obterPorIdHandler)
    {
        _useCase = useCase;
        _obterPorIdHandler = obterPorIdHandler;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] char filtro = 'T')
    {
        var comandas = await _useCase.ExecutarAsync(filtro);

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