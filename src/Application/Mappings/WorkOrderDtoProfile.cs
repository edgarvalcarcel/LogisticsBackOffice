using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.WorkOrders.Command.Modify;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class WorkOrderDtoProfile : Profile
{
    public WorkOrderDtoProfile()
    {
        CreateMap<WorkOrder, WorkOrderDto>().ReverseMap();
        CreateMap<WorkOrderDto, WorkOrder>().ReverseMap();
        CreateMap<ModifyWorkOrderCommand, WorkOrder>();
    }
}
