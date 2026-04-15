using App.Contatos.Application.Dtos;

namespace App.Contatos.Application.Service.Interface;

public interface IContatoService
{
    Task<IEnumerable<ContatoResponseDto>> ObterTodosAsync();
    Task<ContatoResponseDto?> ObterAsync(Guid id);
    Task<ContatoResponseDto> AdicionarAsync(ContatoRequestDto request);
    Task<ContatoResponseDto> AtualizarAsync(Guid id, ContatoRequestDto request);
    Task RemoverAsync(Guid id);
    Task DesativarContatoAsync(Guid id);
}