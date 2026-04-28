namespace App.Application.Dtos;

public class PedidoItemRequestDto
{
    public Guid ProdutoId { get; set; }

    public int Quantidade { get; set; }
}
