namespace App.Application.DTOs.Response;

public class PedidoResponseDto
{
    public Guid Id { get; set; }
    public string NomeCliente { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; } // "Aberto", "Pago" ou "Cancelado"
    public decimal ValorTotal { get; set; }

    // Lista de itens detalhada para o cupom ou conferência
    public List<PedidoItemResponseDto> Itens { get; set; } = new();

    // Endereço formatado (Opcional)
    public EnderecoResponseDto? Endereco { get; set; }
}
