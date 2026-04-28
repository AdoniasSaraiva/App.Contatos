using App.Domain.Enums;

namespace App.Domain.Entities;

public class Pedido : Entity
{
    public string NomeCliente { get; private set; }
        
    public PedidoStatus Status { get; private set; }

    public List<PedidoItem> Itens { get; private set; } = new();

    public Endereco Endereco { get; private set; }

    public MetodoPagamento MetodoPagamento { get; private set; }

    public decimal ValorTotal => Itens.Sum(x => x.PrecoUnitario * x.Quantidade);

    public Pedido(string nomeCliente, string criadoPor, DateTime criadoEm)
    {
        NomeCliente = nomeCliente;
        Status = PedidoStatus.Aberto;
        CriadoEm = criadoEm;
        CriadoPor = criadoPor;
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        if (Status != PedidoStatus.Aberto)
            throw new InvalidOperationException("O pedido já está fechado.");

        var item = new PedidoItem(Id, produto.Id, quantidade, produto.PrecoVenda);
        Itens.Add(item);
    }

    public void Finalizar(int metodoPagamento)
    {
        if (Status != PedidoStatus.Aberto)
            throw new InvalidOperationException("O pedido não pode ser finalizado.");
        
        MetodoPagamento = (MetodoPagamento)metodoPagamento;
        Status = PedidoStatus.Pago;
    }
}