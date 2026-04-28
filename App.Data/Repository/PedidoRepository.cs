using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Interface;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repository;

public class PedidoRepository : IPedidoRepository
{
    private readonly AppDbContext _context;
    public PedidoRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Pedido>> ObterPedidosAbertosAsync() => await _context.Pedidos
            .Include(p => p.Itens)
            .Include(p => p.Endereco) 
            .Where(p => p.Status == PedidoStatus.Aberto)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Pedido?> ObterPorIdAsync(Guid id)
    {
        return await _context.Pedidos
            .Include(p => p.Itens)
            .Include(p => p.Endereco)
            .FirstOrDefaultAsync(p => p.Id == id);

    }

    public async Task AdicionarAsync(Pedido pedido)
        => await _context.Pedidos.AddAsync(pedido);

    public void Atualizar(Pedido pedido)
        => _context.Pedidos.Update(pedido);

    public async Task SalvarAsync()
        => await _context.SaveChangesAsync();
}