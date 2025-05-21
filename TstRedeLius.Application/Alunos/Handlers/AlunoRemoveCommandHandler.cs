using TstRedeLius.Application.Alunos.Commands;
using TstRedeLius.Domain.Entities;
using TstRedeLius.Domain.Interfaces;
using MediatR;

namespace TstRedeLius.Application.Alunos.Handlers;

public class AlunoRemoveCommandHandler : IRequestHandler<AlunoRemoveCommand, Aluno>
{
    private readonly IAlunoRepository _alunoRepository;
    public AlunoRemoveCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository ?? throw new
            ArgumentNullException(nameof(alunoRepository));
    }

    public async Task<Aluno> Handle(AlunoRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var aluno = await _alunoRepository.GetByIdAsync(request.Id);

        if (aluno == null)
        {
            throw new ApplicationException($"Aluno não foi encontrado.");
        }
        else
        {
            var result = await _alunoRepository.RemoveAsync(aluno);
            return result;
        }
    }
}
