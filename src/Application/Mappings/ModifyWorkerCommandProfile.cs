using AutoMapper;
using LogisticsBackOffice.Application.Workers.Commands.Modify;
using LogisticsBackOffice.Domain.Entities;
namespace LogisticsBackOffice.Application.Mappings;
public class ModifyWorkerCommandProfile : Profile
{
    public ModifyWorkerCommandProfile()
    {
        CreateMap<Worker, ModifyWorkerCommand>().ReverseMap();
        CreateMap<ModifyWorkerCommand, Worker>().ReverseMap();
    }
}