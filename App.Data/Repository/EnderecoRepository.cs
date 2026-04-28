using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repository;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly AppDbContext _context;
    public EnderecoRepository(AppDbContext context) => _context = context;

    public async Task AdicionarAsync(Endereco endereco)
    {
        await _context.Set<Endereco>().AddAsync(endereco);
    }

    public async Task<Endereco?> ObterPorPedidoIdAsync(Guid pedidoId)
    {
        return await _context.Set<Endereco>()
            .FirstOrDefaultAsync(e => e.PedidoId == pedidoId);
    }

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}
