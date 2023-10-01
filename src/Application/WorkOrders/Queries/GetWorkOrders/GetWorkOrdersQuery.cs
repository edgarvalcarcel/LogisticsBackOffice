using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.WorkOrders.Queries.GetWorkOrders;
public record GetWorkOrdersQuery() : IRequest<IQueryable<WorkOrder>>;