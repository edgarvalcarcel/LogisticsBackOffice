using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrderById;

public record  GetWorkOrderByIdQuery([ID(nameof(WorkOrder))] int Id) : IRequest<WorkOrder>;
