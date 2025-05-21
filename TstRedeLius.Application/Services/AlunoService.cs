using AutoMapper;
using TstRedeLius.Application.DTOs;
using TstRedeLius.Application.Interfaces;
using TstRedeLius.Application.Alunos.Commands;
using TstRedeLius.Application.Alunos.Queries;
using MediatR;

namespace TstRedeLius.Application.Services;

public class AlunoService : IAlunoService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    public AlunoService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<AlunoDTO>> GetAlunos()
    {
        var alunosQuery = new GetAlunoQuery();

        if (alunosQuery == null)
            throw new Exception($"Não foi possível carregar os alunos.");

        var result = await _mediator.Send(alunosQuery);

        return _mapper.Map<IEnumerable<AlunoDTO>>(result);
    }

    public async Task<AlunoDTO> GetById(int? id)
    {
        var alunotByIdQuery = new GetAlunoByIdQuery(id.Value);

        if (alunotByIdQuery == null)
            throw new Exception($"Aluno não encontrado.");

        var result = await _mediator.Send(alunotByIdQuery);

        return _mapper.Map<AlunoDTO>(result);
    }

    public async Task Add(AlunoDTO alunoDto)
    {
        var alunoCreateCommand = _mapper.Map<AlunoCreateCommand>(alunoDto);
        await _mediator.Send(alunoCreateCommand);
    }

    public async Task Update(AlunoDTO alunoDto)
    {
        var alunoUpdateCommand = _mapper.Map<AlunoUpdateCommand>(alunoDto);
        await _mediator.Send(alunoUpdateCommand);
    }

    public async Task Remove(int? id)
    {
        var alunoRemoveCommand = new AlunoRemoveCommand(id.Value);
        if (alunoRemoveCommand == null)
            throw new Exception($"Aluno não encontrado.");

        await _mediator.Send(alunoRemoveCommand);
    }
}
