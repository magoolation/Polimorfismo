using Microsoft.AspNetCore.Mvc;
using Polimorfismo.Data;

namespace Polimorfismo.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaCorrenteController : ControllerBase
{
    private readonly ExtratoService _extratoService;

    public ContaCorrenteController(ExtratoService extratoService)
    {
        _extratoService = extratoService;
    }
    
    [HttpGet("{id:int}", Name = nameof(SelecionarContaCorrentePorIdAsync))]
    public IActionResult SelecionarContaCorrentePorIdAsync([FromRoute]int id) => Ok(_extratoService.SelecionarExtratoContaCorrente(id));
}