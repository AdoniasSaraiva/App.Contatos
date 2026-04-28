using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Produto>> ObterTodosAsync()
        => await _context.Produtos.AsNoTracking().ToListAsync();

    public async Task<Produto?> ObterPorIdAsync(Guid id)
        => await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

    public async Task AdicionarAsync(Produto produto)
        => await _context.Produtos.AddAsync(produto);

    public void Atualizar(Produto produto)
        => _context.Produtos.Update(produto);

    public async Task AtualizarEstoque(Produto produto)
        => await _context.Produtos
                .Where(p => p.Id == produto.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => p.Estoque, produto.Estoque));

    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}