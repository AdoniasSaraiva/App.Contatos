using App.Application.DTOs.Request;
using App.Application.Service.Interface;
using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Application.Service;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoService(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public async Task<Endereco> SalvarEnderecoPedidoAsync(Guid pedidoId, EnderecoRequestDto dto)
    {
        var endereco = new Endereco(
            dto.Logradouro,
            dto.Numero,
            dto.Bairro,
            dto.Cidade,
            dto.Cep,
            pedidoId,
            dto.Complemento ?? ""
        );

        await _enderecoRepository.AdicionarAsync(endereco);
        return endereco;
    }
}