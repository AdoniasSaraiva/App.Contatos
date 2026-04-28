using App.Domain.Entities;

namespace App.Domain.Interface;

public interface IPedidoRepository
{
    Task<IEnumerable<Pedido>> ObterPedidosAbertosAsync();
    Task<Pedido?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Pedido pedido);
    void Atualizar(Pedido pedido);
    Task SalvarAsync();
}