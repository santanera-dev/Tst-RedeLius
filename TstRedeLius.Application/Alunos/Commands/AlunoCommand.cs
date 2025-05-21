using TstRedeLius.Domain.Entities;
using MediatR;

namespace TstRedeLius.Application.Alunos.Commands;

public abstract class AlunoCommand : IRequest<Aluno>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Serie{ get; set; }
}
