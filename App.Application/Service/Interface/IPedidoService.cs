using App.Application.DTOs.Request;
using App.Application.DTOs.Response;

namespace App.Application.Service.Interface;

public interface IPedidoService
{
    Task<IEnumerable<PedidoResponseDto>> ObterPedidosAbertosAsync();
    Task<PedidoResponseDto> CriarPedidoAsync(PedidoRequestDto request);
    Task<PedidoResponseDto> FinalizarPagamentoAsync(Guid pedidoId, PagamentoRequestDto request);
}