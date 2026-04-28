using App.Domain.Enums;

namespace App.Application.DTOs.Request;

public class ContatoRequestDto
{
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public SexoEnum Sexo { get; set; }
}