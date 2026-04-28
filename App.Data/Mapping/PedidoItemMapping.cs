using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Mapping;

public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.ToTable("PedidosItens");

        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.Quantidade)
            .IsRequired();

        builder.Property(pi => pi.PrecoUnitario)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        // Mapeamento das chaves estrangeiras
        builder.Property(pi => pi.PedidoId)
            .IsRequired();

        builder.Property(pi => pi.ProdutoId)
            .IsRequired();

        // Relacionamento com o Pedido
        builder.HasOne<Pedido>()
            .WithMany(p => p.Itens)
            .HasForeignKey(pi => pi.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        // Se houver uma entidade Produto, o relacionamento seria:
        // builder.HasOne<Produto>().WithMany().HasForeignKey(pi => pi.ProdutoId);
    }
}