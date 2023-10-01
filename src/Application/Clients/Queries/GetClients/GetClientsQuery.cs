using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Queries.GetClients;

public record GetClientsQuery() : IRequest<IEnumerable<Client>>;
