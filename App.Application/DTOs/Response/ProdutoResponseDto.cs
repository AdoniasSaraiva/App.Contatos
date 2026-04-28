namespace App.Application.DTOs.Response;

public class ProdutoResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string CodProduto { get; set; }
    public decimal PrecoVenda { get; set; }
    public decimal PrecoCompra { get; set; }
    public int Estoque { get; set; }
}