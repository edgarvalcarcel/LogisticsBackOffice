using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class StatusDtoProfile : Profile
{
    public StatusDtoProfile()
    {
        CreateMap<Status, StatusDto>().ReverseMap();
        CreateMap<StatusDto, Status>().ReverseMap();
    }
}
