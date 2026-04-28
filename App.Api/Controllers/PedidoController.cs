using App.Application.DTOs.Request;
using App.Application.DTOs.Response;
using App.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _pedidoService;
    public PedidoController(IPedidoService pedidoService) => _pedidoService = pedidoService;

    [HttpGet("abertos")]
    [ProducesResponseType(typeof(IEnumerable<PedidoResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterAbertos() => Ok(await _pedidoService.ObterPedidosAbertosAsync());

    [HttpPost]
    public async Task<ActionResult<PedidoResponseDto>> Criar([FromBody] PedidoRequestDto request)
    {
        var pedido = await _pedidoService.CriarPedidoAsync(request);
        return Created("", pedido);
    }

    [HttpPost("{id:guid}/finalizar")]
    public async Task<ActionResult<PedidoResponseDto>> Finalizar(Guid id, [FromBody] PagamentoRequestDto request)
    {
        var pedidoFinalizado = await _pedidoService.FinalizarPagamentoAsync(id, request);
        return Ok(pedidoFinalizado);
    }
}