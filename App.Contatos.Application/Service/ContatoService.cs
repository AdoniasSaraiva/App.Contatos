using App.Contatos.Application.Dtos;
using App.Contatos.Application.Exceptions;
using App.Contatos.Application.Mappers;
using App.Contatos.Application.Service.Interface;
using App.Contatos.Domain.Interface;

namespace App.Contatos.Application.Service;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _contatoRepository;
    
    public ContatoService(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }
    
    public async Task<IEnumerable<ContatoResponseDto>> ObterTodosAsync()
    {
        var contatos = await _contatoRepository.ObterTodosAsync();
        
        var response = contatos
            .Select(c => ContatoMapper.ToDto(c))
            .ToList();
        
        return response;
    }
    
    public async Task<ContatoResponseDto?> ObterAsync(Guid id)
    {
        var contato = await _contatoRepository.ObterPorIdAsync(id);

        if (contato == null)
            throw new ContatoNotFoundException("Contato não encontrado.");
        
        return ContatoMapper.ToDto(contato);
    }
    
    public async Task<ContatoResponseDto> AdicionarAsync(ContatoRequestDto request)
    {
        var contato = ContatoMapper.ToEntity(request);
        
        await _contatoRepository.AdicionarAsync(contato);
        await _contatoRepository.SalvarAsync();
        
        return ContatoMapper.ToDto(contato);
    }
    
    public async Task<ContatoResponseDto> AtualizarAsync(Guid id, ContatoRequestDto request)
    {
        var contato = await _contatoRepository.ObterPorIdAsync(id);

        if (contato == null)
            throw new ContatoNotFoundException("Contato não encontrado para atualização.");
        
        contato.Atualizar(
            request.Nome,
            request.DataDeNascimento,
            request.Sexo
        );
        
        await _contatoRepository.SalvarAsync();
        
        return ContatoMapper.ToDto(contato);
    }

    
    public async Task RemoverAsync(Guid id)
    {
        var contato = await _contatoRepository.ObterPorIdAsync(id);

        if (contato is null)
            throw new ContatoNotFoundException("Contato não encontrado para remoção.");

        await _contatoRepository.RemoverAsync(contato);
        await _contatoRepository.SalvarAsync();
    }

    public async Task DesativarContatoAsync(Guid id)
    {
        var contato = await _contatoRepository.ObterPorIdAsync(id);
        
        if (contato is null)
            throw new ContatoNotFoundException("Contato não encontrado para inativação.");
        
        contato.InativarStatus();
        await _contatoRepository.SalvarAsync();
    }
}