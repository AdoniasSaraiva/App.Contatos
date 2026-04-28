using App.Application.DTOs.Request;
using App.Application.DTOs.Response;
using App.Application.Service.Interface;
using App.Domain.Entities;
using App.Domain.Interface;
using App.Domain.Interfaces;

namespace App.Application.Service;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IEnderecoService _enderecoService;

    public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository, IEnderecoService enderecoService)
    {
        _pedidoRepository = pedidoRepository;
        _produtoRepository = produtoRepository;
        _enderecoService = enderecoService;
    }

    public async Task<IEnumerable<PedidoResponseDto>> ObterPedidosAbertosAsync()
    {
        var pedidos = await _pedidoRepository.ObterPedidosAbertosAsync();

        return pedidos.Select(p => MapearParaResponse(p));
    }

    public async Task<PedidoResponseDto> CriarPedidoAsync(PedidoRequestDto request)
    {
        var pedido = new Pedido(request.NomeCliente, request.CriadoPor, criadoEm: DateTime.Now);

        // Processa os itens
        foreach (var itemDto in request.Itens)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(itemDto.ProdutoId);
            if (produto != null)
            {
                pedido.AdicionarItem(produto, itemDto.Quantidade);

                produto.DebitarEstoque(itemDto.Quantidade);

                await _produtoRepository.AtualizarEstoque(produto);
            }
        }

        // Adiciona endereço se houver
        if (request.Endereco != null)
        {
            var endereco = await _enderecoService.SalvarEnderecoPedidoAsync(pedido.Id, request.Endereco);
        }

        await _pedidoRepository.AdicionarAsync(pedido);
        await _pedidoRepository.SalvarAsync();

        return MapearParaResponse(pedido);
    }

    public async Task<PedidoResponseDto> FinalizarPagamentoAsync(Guid pedidoId, PagamentoRequestDto request)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(pedidoId) ?? throw new Exception("Pedido não encontrado.");

        pedido.Finalizar(request.MetodoPagamento);

        // Aqui você poderia criar a entidade Pagamento e salvar no banco também

        await _pedidoRepository.SalvarAsync();
        return MapearParaResponse(pedido);
    }

    // Método auxiliar de mapeamento (em um projeto real, use AutoMapper)
    private PedidoResponseDto MapearParaResponse(Pedido p)
    {
        return new PedidoResponseDto
        {
            Id = p.Id,
            NomeCliente = p.NomeCliente,
            DataCriacao = p.CriadoEm,
            Status = p.Status.ToString(),
            ValorTotal = p.ValorTotal,
            Endereco = p.Endereco != null ? new EnderecoResponseDto { 
                Logradouro = p.Endereco.Logradouro, 
                Numero = p.Endereco.Numero, 
                Bairro = p.Endereco.Bairro, 
                Cidade = p.Endereco.Cidade, 
                Cep = p.Endereco.Cep, 
                Complemento = p.Endereco.Complemento } : null
        };
    }
}