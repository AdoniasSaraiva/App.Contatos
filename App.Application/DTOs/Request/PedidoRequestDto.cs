using App.Application.Dtos;

namespace App.Application.DTOs.Request;

public class PedidoRequestDto
{
    public string NomeCliente { get; set; }
    public List<PedidoItemRequestDto> Itens { get; set; }
    public EnderecoRequestDto? Endereco { get; set; } 
    public string CriadoPor { get; set; } = string.Empty;
}
