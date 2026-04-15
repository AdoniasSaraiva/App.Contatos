using App.Contatos.Domain.Entities;

namespace App.Contatos.Domain.Interface;

public interface IContatoRepository
{
    Task<IEnumerable<Contato>> ObterTodosAsync();
    Task<Contato> AdicionarAsync(Contato contato);
    Task<Contato?> ObterPorIdAsync(Guid id);
    Task RemoverAsync(Contato contato);
    Task SalvarAsync();
}