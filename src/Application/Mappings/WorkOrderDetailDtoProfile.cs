using AutoMapper;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Mappings;
public class WorkOrderDetailDtoProfile : Profile
{
    public WorkOrderDetailDtoProfile()
    {
        CreateMap<WorkOrderDetail, WorkOrderDetailDto>().ReverseMap();
        CreateMap<WorkOrderDetailDto, WorkOrderDetail>().ReverseMap();
    }
}


