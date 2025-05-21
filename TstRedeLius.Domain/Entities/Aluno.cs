using TstRedeLius.Domain.Validation;

namespace TstRedeLius.Domain.Entities;

public sealed class Aluno : Entity
{
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Serie { get; private set; }

    public Aluno(string nome, string email, string serie)
    {
        ValidateDomain(nome, email, serie);
    }

    public Aluno(int id, string nome, string email, string serie)
    {
        DomainExceptionValidation.When(id < 0, "Id. inválido!");
        Id = id;
        ValidateDomain(nome, email, serie);
    }

    public void Update(string nome, string email, string serie)
  {
        ValidateDomain(nome, email, serie);
    }

    private void ValidateDomain(string nome, string email, string serie)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
        "Nome deve ser informado!");

        DomainExceptionValidation.When(string.IsNullOrEmpty(email),
        "Email deve ser informado!");

        DomainExceptionValidation.When(string.IsNullOrEmpty(serie),
        "Série deve ser informada!"); 
        
        Nome = nome;
        Email = email;
        Serie = serie;
    }
}
