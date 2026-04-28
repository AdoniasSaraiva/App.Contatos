using App.Domain.Entities;

namespace App.Domain.Interfaces;

public interface IEnderecoRepository
{
    Task AdicionarAsync(Endereco endereco);
    Task<Endereco?> ObterPorPedidoIdAsync(Guid pedidoId);
    Task SalvarAsync();
}