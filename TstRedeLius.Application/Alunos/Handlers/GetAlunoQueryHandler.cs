using TstRedeLius.Application.Alunos.Queries;
using TstRedeLius.Domain.Entities;
using TstRedeLius.Domain.Interfaces;
using MediatR;

namespace TstRedeLius.Application.Alunos.Handlers;

public class GetAlunoQueryHandler : IRequestHandler<GetAlunoQuery, IEnumerable<Aluno>>
{
    private readonly IAlunoRepository _alunoRepository;

    public GetAlunoQueryHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public async Task<IEnumerable<Aluno>> Handle(GetAlunoQuery request,
        CancellationToken cancellationToken)
    {
        return await _alunoRepository.GetAlunoAsync();
    }
}
