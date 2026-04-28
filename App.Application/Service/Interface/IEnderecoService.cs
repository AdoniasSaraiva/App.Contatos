using App.Application.DTOs.Request;
using App.Domain.Entities;

namespace App.Application.Service.Interface;

public interface IEnderecoService
{
    Task<Endereco> SalvarEnderecoPedidoAsync(Guid pedidoId, EnderecoRequestDto dto);
}