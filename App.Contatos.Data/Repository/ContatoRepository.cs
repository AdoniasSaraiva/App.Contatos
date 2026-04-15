using App.Contatos.Data.Data;
using App.Contatos.Domain.Entities;
using App.Contatos.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace App.Contatos.Data.Repository;

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
        _context.Contatos.Remove(contato);
        return Task.CompletedTask;
    }   
        
    public async Task SalvarAsync()
    {
        await _context.SaveChangesAsync();
    }
}