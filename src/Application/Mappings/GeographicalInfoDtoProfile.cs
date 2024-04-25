using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class GeographicalInfoDtoProfile : Profile
{
    public GeographicalInfoDtoProfile()
    {
        CreateMap<GeographicalInfo, GeographicalInfoDto>().ReverseMap();
        CreateMap<GeographicalInfoDto, GeographicalInfo>().ReverseMap();
    }
}
