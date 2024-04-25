using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Mappings;
public class WorkerDtoProfile : Profile
{
    public WorkerDtoProfile()
    {
        CreateMap<Worker, WorkerDto>().ReverseMap();
        CreateMap<WorkerDto, Worker>().ReverseMap();
    }
}
