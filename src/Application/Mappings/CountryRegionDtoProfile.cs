using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class CountryRegionDtoProfile : Profile
{
    public CountryRegionDtoProfile()
    {
        CreateMap<CountryRegion, CountryRegionDto>().ReverseMap();
        CreateMap<CountryRegionDto, CountryRegion>().ReverseMap();
    }
}
