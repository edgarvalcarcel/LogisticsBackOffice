using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class ProjectDetailDtoProfile : Profile
{
    public ProjectDetailDtoProfile()
    {
        CreateMap<ProjectDetail, ProjectDetailDto>().ReverseMap();
        CreateMap<ProjectDetailDto, ProjectDetail>().ReverseMap();
    }
}

