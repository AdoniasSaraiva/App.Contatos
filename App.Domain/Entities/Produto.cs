namespace App.Domain.Entities;

public class Produto : Entity
{
    public string Nome { get; private set; }
    public string CodProduto { get; private set; }
    public decimal PrecoVenda { get; private set; }
    public decimal PrecoCompra { get; private set; }

    public int Estoque { get; private set; }


    protected Produto() { }

    public Produto(Guid id) { Id = id; }

    public Produto(string nome, string codProduto, decimal precoVenda, decimal precoCompra, int estoqueInicial)
    {
        Nome = nome;
        CodProduto = codProduto;
        PrecoVenda = precoVenda;
        PrecoCompra = precoCompra;
        Estoque = estoqueInicial;
    }

    public void DebitarEstoque(int quantidade)
    {
        if (quantidade > Estoque)
            throw new InvalidOperationException("Estoque insuficiente para esta venda.");

        Estoque -= quantidade;
    }
}