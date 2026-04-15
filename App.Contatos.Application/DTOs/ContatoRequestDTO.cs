// Comentário: DTO de requisição usado para criar/atualizar contatos via API.
using App.Contatos.Domain.Enums;

namespace App.Contatos.Application.Dtos;

public class ContatoRequestDto
{
    public string Nome { get; set; }
    public DateTime DataDeNascimento { get; set; }
    public SexoEnum Sexo { get; set; }
}