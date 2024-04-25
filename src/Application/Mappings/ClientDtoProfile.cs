using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class ClientDtoProfile : Profile
{
    public ClientDtoProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<ClientDto, Client>().ReverseMap();
    }
}
