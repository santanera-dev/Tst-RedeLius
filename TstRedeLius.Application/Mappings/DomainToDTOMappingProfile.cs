using AutoMapper;
using TstRedeLius.Application.DTOs;
using TstRedeLius.Domain.Entities;

namespace TstRedeLius.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Aluno, AlunoDTO>().ReverseMap();
    }
}
