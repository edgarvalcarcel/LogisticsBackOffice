using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Mappings;
public class ServiceDtoProfile : Profile
{
    public ServiceDtoProfile()
    {
        CreateMap<Service, ServiceDto>().ReverseMap();
        CreateMap<ServiceDto, Service>().ReverseMap();
    }
}