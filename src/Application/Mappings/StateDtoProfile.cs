using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class StateDtoProfile : Profile
{
    public StateDtoProfile()
    {
        CreateMap<StateDto, State>().ReverseMap();
        CreateMap<State, StateDto>().ReverseMap();
    }
}
