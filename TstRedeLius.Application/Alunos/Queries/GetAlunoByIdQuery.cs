using TstRedeLius.Domain.Entities;
using MediatR;

namespace TstRedeLius.Application.Alunos.Queries;

public class GetAlunoByIdQuery : IRequest<Aluno>
{
    public int Id { get; set; }
    public GetAlunoByIdQuery(int id)
    {
        Id = id;
    }
}
