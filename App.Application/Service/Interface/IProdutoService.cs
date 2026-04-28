using App.Application.DTOs.Request;
using App.Application.DTOs.Response;

namespace App.Application.Service.Interface;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoResponseDto>> ObterTodosAsync();
    Task<ProdutoResponseDto> ObterPorIdAsync(Guid id);
    Task<ProdutoResponseDto> AdicionarAsync(ProdutoRequestDto request);
}
