using AutoMapper;
using LogisticsBackOffice.Application.Projects.Commands.Modify;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class ProjectDtoProfile : Profile
{
    public ProjectDtoProfile()
    {
        CreateMap<ProjectDto, Project>().ReverseMap();
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<ModifyProjectCommand, Project>()
                .AfterMap((src, dest) =>
                {
                    dest.GeographicalInfo = null;
                    dest.CourierCompany = null;
                    dest.Contact = null;
                    dest.CourierCompany = null;
                });
    }
}

