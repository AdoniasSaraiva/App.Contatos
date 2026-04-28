using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Mapping;

public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("Enderecos");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Logradouro)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.Numero)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.Complemento)
            .HasMaxLength(150);

        builder.Property(e => e.Bairro)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Cep)
            .IsRequired()
            .HasMaxLength(10);

        // Relacionamento 1:1 com o Pedido
        builder.HasOne<Pedido>()
            .WithOne(p => p.Endereco)
            .HasForeignKey<Endereco>(e => e.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}