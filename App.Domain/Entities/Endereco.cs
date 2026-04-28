namespace App.Domain.Entities;

public class Endereco : Entity
{
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Cep { get; private set; }

    public Guid PedidoId { get; private set; }

    public Endereco(string logradouro, string numero, string bairro, string cidade, string cep, Guid pedidoId, string complemento = "")
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Cep = cep;
        PedidoId = pedidoId;
        Complemento = complemento;
    }
}