namespace App.Application.DTOs.Request;

public class PagamentoRequestDto
{
    // Opcional se o ID vier pela URL da rota, mas bom ter para validação
    public Guid PedidoId { get; set; }

    public decimal ValorPago { get; set; }

    // Representa o Enum (1: Dinheiro, 2: Cartao, 3: Pix)
    public int MetodoPagamento { get; set; }
}