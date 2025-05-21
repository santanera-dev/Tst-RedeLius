using TstRedeLius.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace TstRedeLius.Application.Alunos.Queries;

public class GetAlunoQuery : IRequest<IEnumerable<Aluno>>
{
}
