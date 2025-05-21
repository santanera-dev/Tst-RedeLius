using TstRedeLius.Domain.Entities;

namespace TstRedeLius.Domain.Interfaces;

public interface IAlunoRepository
{
    Task<IEnumerable<Aluno>> GetAlunoAsync();
    Task<Aluno> GetByIdAsync(int? id);

    Task<Aluno> CreateAsync(Aluno aluno);
    Task<Aluno> UpdateAsync(Aluno aluno);
    Task<Aluno> RemoveAsync(Aluno aluno);
}
