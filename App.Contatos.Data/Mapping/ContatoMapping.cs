using App.Contatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Contatos.Data.Mapping;

public class ContatoMapping : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.ToTable("Contatos"); 
        
        builder.HasKey(c => c.Id); 

        builder.Property(c => c.Nome)
            .IsRequired() 
            .HasMaxLength(100); 
        
        builder.Property(c => c.DataDeNascimento)
            .IsRequired() 
            .HasColumnType("DATE");

        builder.Property(c => c.SexoEnum)
            .IsRequired();
        
        builder.HasQueryFilter(c => c.Ativo);
    }
}