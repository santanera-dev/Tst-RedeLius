using TstRedeLius.Application.Alunos.Queries;
using TstRedeLius.Domain.Entities;
using TstRedeLius.Domain.Interfaces;
using MediatR;

namespace TstRedeLius.Application.Alunos.Handlers;

public class GetAlunoByIdQueryHandler : IRequestHandler<GetAlunoByIdQuery, Aluno>
{
    private readonly IAlunoRepository _alunotRepository;
    public GetAlunoByIdQueryHandler(IAlunoRepository alunoRepository)
    {
        _alunotRepository = alunoRepository;
    }

    public async Task<Aluno> Handle(GetAlunoByIdQuery request,
         CancellationToken cancellationToken)
    {
        return await _alunotRepository.GetByIdAsync(request.Id);
    }
}
