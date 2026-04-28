using App.Domain.Enums;
using App.Domain.Exceptions;

namespace App.Domain.Entities;

public class Contato : Entity
{
    public string Nome { get; private set; }
    public DateTime DataDeNascimento { get; private set; }
    public SexoEnum SexoEnum { get; private set; }
    public bool Ativo { get; private set; }
    public int Idade => CalcularIdade(DataDeNascimento);

    protected Contato() {}
    
    private Contato(string nome, DateTime dataDeNascimento, SexoEnum sexoEnum)
    {
        Nome = nome;
        DataDeNascimento = dataDeNascimento;
        SexoEnum = sexoEnum;
        Ativo = true;
    }
    
    public static Contato Criar(string nome, DateTime dataDeNascimento, SexoEnum sexoEnum)
    {
        Validar(nome, dataDeNascimento, sexoEnum);

        return new Contato(nome, dataDeNascimento, sexoEnum);
    }
    
    public void Atualizar(string nome, DateTime dataDeNascimento, SexoEnum sexoEnum)
    {
        Validar(nome, dataDeNascimento, sexoEnum);
        
        if (!Ativo)
            throw new DomainException("Contato desativado não pode ser alterado.");

        Nome = nome;
        DataDeNascimento = dataDeNascimento;
        SexoEnum = sexoEnum;
    }
    
    private static void Validar(string nome, DateTime dataDeNascimento, SexoEnum sexoEnum)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Nome do contato não pode ser nulo ou vazio.");
        
        if (dataDeNascimento > DateTime.Today)
            throw new DomainException("A data de nascimento não pode ser maior que a data atual.");
        
        var idade = CalcularIdade(dataDeNascimento);
         
        if (idade == 0)
            throw new DomainException("A idade do contato não pode ser 0.");

        if (idade < 18)
            throw new DomainException("O contato deve ser maior que 18 anos.");
        
        if (!Enum.IsDefined(sexoEnum))
            throw new DomainException("Sexo inválido. Defina apenas 'Masculino' ou 'Feminino'.");
    }
    
    private static int CalcularIdade(DateTime dataDeNascimento)
    {
        var hoje = DateTime.Now;
        var idade = hoje.Year - dataDeNascimento.Year;
        if (dataDeNascimento.Date > hoje.AddYears(-idade))
        {
            idade -= 1;
        }
        return idade;
    }
    
    public void InativarStatus() => Ativo = false;
}
