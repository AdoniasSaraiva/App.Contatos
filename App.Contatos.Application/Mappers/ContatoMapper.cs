using App.Contatos.Application.Dtos;
using App.Contatos.Domain.Entities;

namespace App.Contatos.Application.Mappers;

public class ContatoMapper
{
    public static Contato ToEntity(ContatoRequestDto dto)
    {
        return Contato.Criar(
            dto.Nome,
            dto.DataDeNascimento,
            dto.Sexo);
    }
    
    public static ContatoResponseDto ToDto(Contato entity)
    {
        return new ContatoResponseDto(
            entity.Id,                
            entity.Nome,
            entity.DataDeNascimento,
            entity.SexoEnum,
            entity.Ativo,
            entity.Idade
        );
    }
}