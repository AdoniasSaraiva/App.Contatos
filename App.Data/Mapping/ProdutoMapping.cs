using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Mapping;

public class ProdutoMapping : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.CodProduto)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.PrecoVenda)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.PrecoCompra)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Estoque)
            .IsRequired();
    }
}