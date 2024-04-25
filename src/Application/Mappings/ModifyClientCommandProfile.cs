using AutoMapper;
using LogisticsBackOffice.Application.Clients.Commands.Modify;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class ModifyClientCommandProfile : Profile
{
    public ModifyClientCommandProfile()
    {
        CreateMap<Client, ModifyClientCommand>().ReverseMap();
        CreateMap<ModifyClientCommand, Client>().ReverseMap();
    }
}