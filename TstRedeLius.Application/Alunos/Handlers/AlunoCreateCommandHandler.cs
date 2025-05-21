using TstRedeLius.Application.Alunos.Commands;
using TstRedeLius.Domain.Entities;
using TstRedeLius.Domain.Interfaces;
using MediatR;

namespace TstRedeLius.Application.Alunos.Handlers;

public class AlunoCreateCommandHandler : IRequestHandler<AlunoCreateCommand, Aluno>
{
    private readonly IAlunoRepository _alunotRepository;
    public AlunoCreateCommandHandler(IAlunoRepository alunoRepository)
    {
        _alunotRepository = alunoRepository;
    }
    public async Task<Aluno> Handle(AlunoCreateCommand request,
        CancellationToken cancellationToken)
    {
        var aluno = new Aluno(request.Nome, request.Email, request.Serie);

        if (aluno == null)
        {
            throw new ApplicationException($"Erro ao criar o aluno.");
        }
        else
        {
            return await _alunotRepository.CreateAsync(aluno);
        }
    }
}
