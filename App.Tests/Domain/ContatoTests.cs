
using App.Domain.Entities;
using App.Domain.Enums;
using App.Domain.Exceptions;

namespace App.Tests.Domain;
public class ContatoTests
{
    private DateTime DataValida() => DateTime.Today.AddYears(-20);

    [Fact]
    public void Deve_Criar_Contato_Valido()
    {
        var contato = Contato.Criar("Bruno", DataValida(), SexoEnum.Masculino);

        Assert.Equal("Bruno", contato.Nome);
        Assert.True(contato.Ativo);
        Assert.Equal(SexoEnum.Masculino, contato.SexoEnum);
    }

    [Fact]
    public void Nao_Deve_Criar_Com_Nome_Vazio()
    {
        Assert.Throws<DomainException>(() =>
            Contato.Criar("", DataValida(), SexoEnum.Masculino));
    }

    [Fact]
    public void Nao_Deve_Criar_Com_Data_Futura()
    {
        var dataFutura = DateTime.Today.AddDays(1);

        Assert.Throws<DomainException>(() =>
            Contato.Criar("Bruno", dataFutura, SexoEnum.Masculino));
    }

    [Fact]
    public void Nao_Deve_Criar_Menor_De_18()
    {
        var menor = DateTime.Today.AddYears(-17);

        Assert.Throws<DomainException>(() =>
            Contato.Criar("Bruno", menor, SexoEnum.Masculino));
    }

    [Fact]
    public void Nao_Deve_Criar_Com_Sexo_Invalido()
    {
        var sexoInvalido = (SexoEnum)99;

        Assert.Throws<DomainException>(() =>
            Contato.Criar("Bruno", DateTime.Today.AddYears(-20), sexoInvalido)
        );
    }

    [Fact]
    public void Deve_Atualizar_Contato_Ativo()
    {
        var contato = Contato.Criar("Bruno", DataValida(), SexoEnum.Masculino);

        contato.Atualizar("Carlos", DataValida(), SexoEnum.Masculino);

        Assert.Equal("Carlos", contato.Nome);
    }

    [Fact]
    public void Nao_Deve_Atualizar_Contato_Inativo()
    {
        var contato = Contato.Criar("Bruno", DataValida(), SexoEnum.Masculino);

        contato.InativarStatus();

        Assert.Throws<DomainException>(() =>
            contato.Atualizar("Carlos", DataValida(), SexoEnum.Masculino));
    }

    [Fact]
    public void Deve_Alterar_Status()
    {
        var contato = Contato.Criar("Bruno", DataValida(), SexoEnum.Masculino);

        var statusInicial = contato.Ativo;

        contato.InativarStatus();

        Assert.NotEqual(statusInicial, contato.Ativo);
    }
    
    [Fact]
    public void Deve_Lancar_Excecao_Quando_Idade_For_Zero()
    {
        var dataNascimentoHoje = DateTime.Today;

        var exception = Assert.Throws<DomainException>(() =>
            Contato.Criar(
                "Bruno",
                dataNascimentoHoje,
                SexoEnum.Masculino));

        Assert.Equal("A idade do contato não pode ser 0.", exception.Message);
    }

    [Fact]
    public void Deve_Calcular_Idade_Corretamente()
    {
        var data = DateTime.Today.AddYears(-30);

        var contato = Contato.Criar("Bruno", data, SexoEnum.Masculino);

        Assert.Equal(30, contato.Idade);
    }
    
    [Fact]
    public void Deve_Calcular_Idade_Corretamente_Quando_Nao_Fez_Aniversario_Ainda()
    {
        var dataNascimento = DateTime.Today.AddYears(-20).AddDays(1);

        var contato = Contato.Criar("Bruno", dataNascimento, SexoEnum.Masculino);

        Assert.Equal(19, contato.Idade);
    }
}