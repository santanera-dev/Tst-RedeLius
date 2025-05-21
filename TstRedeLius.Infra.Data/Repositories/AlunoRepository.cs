using TstRedeLius.Domain.Entities;
using TstRedeLius.Domain.Interfaces;
using TstRedeLius.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace TstRedeLius.Infra.Data.Repositories;

public class AlunoRepository : IAlunoRepository
{
  private ApplicationDbContext _alunoContext;
  public AlunoRepository(ApplicationDbContext context)
  {
      _alunoContext = context;
  }

  public async Task<Aluno> CreateAsync(Aluno aluno)
  {
      _alunoContext.Add(aluno);
      await _alunoContext.SaveChangesAsync();
      return aluno;
  }

  public async Task<IEnumerable<Aluno>> GetAlunoAsync()
  {
      return await _alunoContext.Alunos.ToListAsync();
  }
  public async Task<Aluno> GetByIdAsync(int? id)
  {
    return await _alunoContext.Alunos.FirstOrDefaultAsync(m => m.Id == id);
  }

  public async Task<Aluno> RemoveAsync(Aluno aluno)
  {
      _alunoContext.Remove(aluno);
      await _alunoContext.SaveChangesAsync();
      return aluno;
  }

  public async Task<Aluno> UpdateAsync(Aluno aluno)
  {
      _alunoContext.Update(aluno);
      await _alunoContext.SaveChangesAsync();
      return aluno;
  }
}
