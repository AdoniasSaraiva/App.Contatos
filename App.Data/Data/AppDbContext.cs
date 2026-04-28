using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Contato> Contatos { get; set;}
    public DbSet<Pedido> Pedidos { get; set;}
    public DbSet<Produto> Produtos { get; set;}
    public DbSet<Endereco> Endereco { get; set;}
    public DbSet<PedidoItem> PedidoItem { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}