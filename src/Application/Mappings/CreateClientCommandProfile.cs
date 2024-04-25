using AutoMapper;
using LogisticsBackOffice.Application.Clients.Commands.Create;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class CreateClientCommandProfile : Profile
{
    public CreateClientCommandProfile()
    {
        CreateMap<Client, CreateClientCommand>().ReverseMap();
        CreateMap<CreateClientCommand, Client>().ReverseMap();
    }
}
