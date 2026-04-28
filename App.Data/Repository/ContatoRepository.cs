using App.Domain.Entities;
using App.Domain.Interface;
using App.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly AppDbContext _context;
    
    public ContatoRepository(AppDbContext context)
    {
        _context = context;
    }    
    
    public async Task<IEnumerable<Contato>> ObterTodosAsync()
    {
        return await _context.Contatos.Where(c => c.Ativo).AsNoTracking().ToListAsync();
    }
        
    public async Task<Contato> AdicionarAsync(Contato contato)
    {
        await _context.Contatos.AddAsync(contato);
        return contato;
    }    
    
    public async Task<Contato?> ObterPorIdAsync(Guid id)
    {
        return await _context.Contatos.FirstOrDefaultAsync(c => c.Id == id);
    }
    
    public Task RemoverAsync(Contato contato)
    {
        _context.Remove(contato);
        return Task.CompletedTask;
    }   
        
    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}