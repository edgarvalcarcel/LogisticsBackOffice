using AutoMapper;
using LogisticsBackOffice.Application.Workers.Commands.Create;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class CreateWorkerCommandProfile : Profile
{
    public CreateWorkerCommandProfile()
    {
        CreateMap<Worker, CreateWorkerCommand>().ReverseMap();
        CreateMap<CreateWorkerCommand, Worker>().ReverseMap();
    }
}