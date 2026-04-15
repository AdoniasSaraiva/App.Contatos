using App.Contatos.Application.Dtos;
using App.Contatos.Application.Exceptions;
using App.Contatos.Application.Service;
using App.Contatos.Domain.Entities;
using App.Contatos.Domain.Enums;
using App.Contatos.Domain.Interface;
using Moq;
using Xunit;

namespace App.Contatos.Tests.Application;

public class ContatoServiceTests
{
    private readonly Mock<IContatoRepository> _repositoryMock;
    private readonly ContatoService _service;

    public ContatoServiceTests()
    {
        _repositoryMock = new Mock<IContatoRepository>();
        _service = new ContatoService(_repositoryMock.Object);
    }

    private Contato CriarContatoValido()
    {
        return Contato.Criar("Bruno", DateTime.Today.AddYears(-20), SexoEnum.Masculino);
    }
    
    
    [Fact]
    public async Task Deve_Retornar_Lista_De_Contatos()
    {
        var contatos = new List<Contato>
        {
            CriarContatoValido(),
            CriarContatoValido()
        };

        _repositoryMock
            .Setup(r => r.ObterTodosAsync())
            .ReturnsAsync(contatos);

        var result = await _service.ObterTodosAsync();

        Assert.Equal(2, result.Count());
    }
    
    
    [Fact]
    public async Task Deve_Retornar_Contato_Por_Id()
    {
        var contato = CriarContatoValido();

        _repositoryMock
            .Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(contato);

        var result = await _service.ObterAsync(Guid.NewGuid());

        Assert.Equal(contato.Nome, result?.Nome);
    }
    
    [Fact]
    public async Task Deve_Lancar_Excecao_Quando_Contato_Nao_Encontrado()
    {
        _repositoryMock
            .Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync((Contato)null!);

        await Assert.ThrowsAsync<ContatoNotFoundException>(() =>
            _service.ObterAsync(Guid.NewGuid()));
    }
    
    
    [Fact]
    public async Task Deve_Adicionar_Contato()
    {
        var request = new ContatoRequestDto
        {
            Nome = "Bruno",
            DataDeNascimento = DateTime.Today.AddYears(-20),
            Sexo = SexoEnum.Masculino
        };

        var result = await _service.AdicionarAsync(request);

        _repositoryMock.Verify(r => r.AdicionarAsync(It.IsAny<Contato>()), Times.Once);
        _repositoryMock.Verify(r => r.SalvarAsync(), Times.Once);

        Assert.Equal("Bruno", result.Nome);
    }
    
    
    [Fact]
    public async Task Deve_Atualizar_Contato()
    {
        var contato = CriarContatoValido();

        _repositoryMock
            .Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(contato);

        var request = new ContatoRequestDto
        {
            Nome = "Carlos",
            DataDeNascimento = DateTime.Today.AddYears(-25),
            Sexo = SexoEnum.Masculino
        };

        var result = await _service.AtualizarAsync(Guid.NewGuid(), request);

        _repositoryMock.Verify(r => r.SalvarAsync(), Times.Once);

        Assert.Equal("Carlos", result.Nome);
    }
    
    
    [Fact]
    public async Task Deve_Remover_Contato()
    {
        var contato = CriarContatoValido();

        _repositoryMock
            .Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(contato);

        await _service.RemoverAsync(Guid.NewGuid());

        _repositoryMock.Verify(r => r.RemoverAsync(contato), Times.Once);
        _repositoryMock.Verify(r => r.SalvarAsync(), Times.Once);
    }
    
    
    [Fact]
    public async Task Deve_Alterar_Status()
    {
        var contato = CriarContatoValido();

        _repositoryMock
            .Setup(r => r.ObterPorIdAsync(It.IsAny<Guid>()))
            .ReturnsAsync(contato);

        var statusInicial = contato.Ativo;

        await _service.DesativarContatoAsync(Guid.NewGuid());

        _repositoryMock.Verify(r => r.SalvarAsync(), Times.Once);
        Assert.NotEqual(statusInicial, contato.Ativo);
    }
}