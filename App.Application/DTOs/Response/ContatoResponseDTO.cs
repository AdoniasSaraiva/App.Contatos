using App.Domain.Enums;

namespace App.Application.DTOs.Response;

public class ContatoResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public SexoEnum SexoEnum { get; set; }
    public bool Ativo { get; private set; }
    public int Idade { get; set; }
    
    public ContatoResponseDto(Guid id, string nome, DateTime dataDeNascimento, SexoEnum sexoEnum, bool ativo, int idade)
    {
        Id  = id;
        Nome = nome;
        DataDeNascimento = dataDeNascimento;
        SexoEnum = sexoEnum;
        Ativo = ativo;
        Idade = idade;
    }
}