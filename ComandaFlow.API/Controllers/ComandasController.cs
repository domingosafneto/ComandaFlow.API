using Microsoft.AspNetCore.Mvc;
using ComandaFlow.Application.Comandas.ListarComandas;

namespace ComandaFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComandasController : ControllerBase
{
    private readonly ListarComandasUseCase _useCase;

    public ComandasController(
        ListarComandasUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] char filtro = 'T')
    {
        var comandas = await _useCase.ExecutarAsync(filtro);

        return Ok(comandas);
    }
}