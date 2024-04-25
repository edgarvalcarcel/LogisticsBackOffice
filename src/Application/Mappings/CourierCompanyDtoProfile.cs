using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class CourierCompanyDtoProfile : Profile
{
    public CourierCompanyDtoProfile()
    {
        CreateMap<CourierCompany, CourierCompanyDto>().ReverseMap();
        CreateMap<CourierCompanyDto, CourierCompany>().ReverseMap();
    }
}
