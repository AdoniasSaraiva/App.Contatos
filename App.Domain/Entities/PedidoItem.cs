namespace App.Domain.Entities;

public class PedidoItem : Entity
{
    public Guid PedidoId { get; private set; }
    public Guid ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }

    public PedidoItem(Guid pedidoId, Guid produtoId, int quantidade, decimal precoUnitario)
    {
        PedidoId = pedidoId;
        ProdutoId = produtoId;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
    }
}