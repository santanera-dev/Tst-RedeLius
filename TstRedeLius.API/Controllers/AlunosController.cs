using TstRedeLius.Application.DTOs;
using TstRedeLius.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TstRedeLius.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _alunoService;
    public AlunosController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlunoDTO>>> Get()
    {
        var alunos = await _alunoService.GetAlunos();
        if (alunos == null)
        {
            return NotFound("Alunos não encontrados.");
        }
        return Ok(alunos);
    }

    [HttpGet("{id}", Name = "GetAluno")]
    public async Task<ActionResult<AlunoDTO>> Get(int id)
    {
        var aluno = await _alunoService.GetById(id);
        if (aluno == null)
        {
            return NotFound("Aluno não econtrado.");
        }
        return Ok(aluno);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] AlunoDTO alunoDto)
    {
        if (alunoDto == null)
            return BadRequest("Dados inválidos.");

        await _alunoService.Add(alunoDto);

        return new CreatedAtRouteResult("GetAluno",
            new { id = alunoDto.Id }, alunoDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] AlunoDTO alunoDto)
    {
        if (id != alunoDto.Id)
        {
            return BadRequest("Dados inválidos");
        }

        if (alunoDto == null)
            return BadRequest("Dados inválidos");

        await _alunoService.Update(alunoDto);

        return Ok(alunoDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AlunoDTO>> Delete(int id)
    {
        var alunoDto = await _alunoService.GetById(id);

        if (alunoDto == null)
        {
            return NotFound("Aluno não encontrado.");
        }

        await _alunoService.Remove(id);

        return Ok(alunoDto);
    }
}
