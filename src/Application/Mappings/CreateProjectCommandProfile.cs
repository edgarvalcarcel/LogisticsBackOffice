using AutoMapper;
using LogisticsBackOffice.Application.Projects.Commands.Create;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class CreateProjectCommandProfile : Profile
{
    public CreateProjectCommandProfile()
    {
        CreateMap<Project, CreateProjectCommand>().ReverseMap();
        CreateMap<CreateProjectCommand, Project>().ReverseMap();
    }
}
