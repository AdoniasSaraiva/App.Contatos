using App.Application.DTOs.Request;
using App.Application.DTOs.Response;
using App.Domain.Entities;

namespace App.Application.Mappers;

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