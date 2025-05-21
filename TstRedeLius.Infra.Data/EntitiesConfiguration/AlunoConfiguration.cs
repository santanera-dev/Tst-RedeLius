using TstRedeLius.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TstRedeLius.Infra.Data.EntitiesConfiguration;

public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
        builder.Property(p => p.Serie).HasMaxLength(20).IsRequired();
  }
}
