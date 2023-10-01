using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Queries.GetServices;

public record GetServicesQuery() : IRequest<IQueryable<Service>>;
 
