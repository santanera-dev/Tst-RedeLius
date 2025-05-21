using AutoMapper;
using TstRedeLius.Application.DTOs;
using TstRedeLius.Application.Alunos.Commands;

namespace TstRedeLius.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<AlunoDTO, AlunoCreateCommand>();
        CreateMap<AlunoDTO, AlunoUpdateCommand>();
    }
}
