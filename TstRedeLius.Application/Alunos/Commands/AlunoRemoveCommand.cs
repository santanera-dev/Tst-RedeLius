using TstRedeLius.Domain.Entities;
using MediatR;

namespace TstRedeLius.Application.Alunos.Commands;

public class AlunoRemoveCommand : IRequest<Aluno>
{
    public int Id { get; set; }
    public AlunoRemoveCommand(int id)
    {
        Id = id;
    }
}
