using AutoMapper;
using LogisticsBackOffice.Application.WorkOrders.Command.Create;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class CreateWorkOrderCommandProfile : Profile
{
    public CreateWorkOrderCommandProfile()
    {
        CreateMap<WorkOrder, CreateWorkOrderCommand>().ReverseMap();
        CreateMap<CreateWorkOrderCommand, WorkOrder>().ReverseMap();
    }
}
