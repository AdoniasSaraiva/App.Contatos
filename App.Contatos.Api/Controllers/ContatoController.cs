using App.Contatos.Application.Dtos;
using App.Contatos.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace App.Contatos.Api.Controllers;

[ApiController]
[Route("api/contatos")]
public class ContatoController : ControllerBase
{
    private readonly IContatoService _contatoService;
    
    public ContatoController(IContatoService contatoService)
    {
        _contatoService = contatoService;
    }

    
    [HttpGet]
    [ProducesResponseType(typeof(ActionResult),StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterTodos()
    {
        var contatos = await _contatoService.ObterTodosAsync();
        return Ok(contatos);
    }

    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ActionResult),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContatoResponseDto?>> ObterPorId(Guid id)
    {
        var  contato = await _contatoService.ObterAsync(id);
        return Ok(contato);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<ContatoResponseDto>> Adicionar([FromBody] ContatoRequestDto request)
    {
        var contato = await _contatoService.AdicionarAsync(request);
        return Created("", contato);
    }

    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(ActionResult),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContatoResponseDto>> Atualizar(Guid id, [FromBody] ContatoRequestDto request)
    {
        var contato = await _contatoService.AtualizarAsync(id, request);
        return Ok(contato);
    }

    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ActionResult),StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Remover(Guid id)
    {
        await _contatoService.RemoverAsync(id);
        return NoContent();
    }

    
    [HttpPatch("{id:guid}/Desativar")]
    [ProducesResponseType(typeof(ActionResult),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DesativarContato(Guid id)
    {
        await _contatoService.DesativarContatoAsync(id);
        return Ok(new { message = "Contato desativado com sucesso!" });
    }
}