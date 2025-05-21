using TstRedeLius.Application.Alunos.Commands;
using TstRedeLius.Domain.Entities;
using TstRedeLius.Domain.Interfaces;
using MediatR;

namespace TstRedeLius.Application.Alunos.Handlers;

public class AlunoUpdateCommandHandler : IRequestHandler<AlunoUpdateCommand, Aluno>
{
    private readonly IAlunoRepository _alunoRepository;
    public AlunoUpdateCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository ??
        throw new ArgumentNullException(nameof(alunoRepository));
    }

    public async Task<Aluno> Handle(AlunoUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var aluno = await _alunoRepository.GetByIdAsync(request.Id);

        if (aluno == null)
        {
            throw new ApplicationException($"Aluno não foi encontrado.");
        }
        else
        {
            aluno.Update(request.Nome, request.Email, request.Serie);

            return await _alunoRepository.UpdateAsync(aluno);

        }
    }
}
