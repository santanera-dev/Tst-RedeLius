using TstRedeLius.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.ConstrainedExecution;

namespace TstRedeLius.Application.DTOs;

public class AlunoDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome deve ser informado!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Email deve ser informado!")]
    [MinLength(7)]
    [MaxLength(50)]
    [DisplayName("Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Série deve ser informada!")]
    [MinLength(1)]
    [MaxLength(20)]
    [DisplayName("Serie")]
    public string Serie { get; set; }
}
