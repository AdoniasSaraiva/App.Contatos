using App.Application.DTOs.Request;
using App.Application.DTOs.Response;
using App.Application.Service.Interface;
using App.Domain.Entities;
using App.Domain.Interfaces;

namespace App.Application.Service;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<IEnumerable<ProdutoResponseDto>> ObterTodosAsync()
    {
        var produtos = await _produtoRepository.ObterTodosAsync();
         
        return produtos.Select(p => new ProdutoResponseDto
        {
            Id = p.Id,
            Nome = p.Nome,
            CodProduto = p.CodProduto,
            PrecoVenda = p.PrecoVenda,
            PrecoCompra = p.PrecoCompra,
            Estoque = p.Estoque
        });
    }

    public async Task<ProdutoResponseDto> ObterPorIdAsync(Guid id)
    {
        var produto = await _produtoRepository.ObterPorIdAsync(id);
        if (produto == null) return null;

        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            CodProduto = produto.CodProduto,
            PrecoVenda = produto.PrecoVenda,
            PrecoCompra = produto.PrecoCompra,
            Estoque = produto.Estoque
        };
    }

    public async Task<ProdutoResponseDto> AdicionarAsync(ProdutoRequestDto request)
    {
        var produto = new Produto(request.Nome, request.CodProduto, request.PrecoVenda, request.PrecoCompra, request.EstoqueInicial);

        await _produtoRepository.AdicionarAsync(produto);

        await _produtoRepository.SalvarAsync();

        return new ProdutoResponseDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            CodProduto = produto.CodProduto,
            PrecoVenda = produto.PrecoVenda,
            PrecoCompra = produto.PrecoCompra,
            Estoque = produto.Estoque
        };
    }
}