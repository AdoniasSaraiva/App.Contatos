using App.Domain.Entities;

namespace App.Domain.Interfaces;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> ObterTodosAsync();
    Task<Produto?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(Produto produto);
    void Atualizar(Produto produto);
    Task SalvarAsync();
    Task AtualizarEstoque(Produto produto);
}