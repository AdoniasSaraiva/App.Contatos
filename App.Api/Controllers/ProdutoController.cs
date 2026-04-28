using App.Application.DTOs.Request;
using App.Application.DTOs.Response;
using App.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;
    public ProdutoController(IProdutoService produtoService) => _produtoService = produtoService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProdutoResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ObterTodos() => Ok(await _produtoService.ObterTodosAsync());

    [HttpPost]
    public async Task<ActionResult<ProdutoResponseDto>> Adicionar([FromBody] ProdutoRequestDto request)
    {
        var produto = await _produtoService.AdicionarAsync(request);
        return Created("", produto);
    }
}