using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Mapping;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        // Define o nome da tabela
        builder.ToTable("Pedidos");

        // Chave Primária (Herdada da classe base Entity)
        builder.HasKey(p => p.Id);

        // Nome do Cliente - Obrigatório conforme sua tela de confirmação
        builder.Property(p => p.NomeCliente)
            .IsRequired()
            .HasMaxLength(200);

        // Mapeamento de Enums (Status e MetodoPagamento)
        // Salva como string no banco para facilitar a leitura manual, ou int para performance
        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(p => p.MetodoPagamento)
            .HasConversion<string>();

        // Propriedades de Auditoria (vistas no seu construtor)
        builder.Property(p => p.CriadoEm)
            .IsRequired();

        builder.Property(p => p.CriadoPor)
            .IsRequired()
            .HasMaxLength(100);
    }
}