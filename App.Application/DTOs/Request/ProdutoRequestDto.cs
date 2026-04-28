namespace App.Application.DTOs.Request;

public class ProdutoRequestDto
{
    public string Nome { get; set; }
    public string CodProduto { get; set; }
    public decimal PrecoVenda { get; set; }
    public decimal PrecoCompra { get; set; }
    public int EstoqueInicial { get; set; }
}
