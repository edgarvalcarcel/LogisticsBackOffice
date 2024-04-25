using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Mappings;
public class ClientContactDtoProfile : Profile
{
    public ClientContactDtoProfile()
    {
        CreateMap<ClientContact, ClientContactDto>().ReverseMap();
        CreateMap<ClientContactDto, ClientContact>().ReverseMap();
    }
}
