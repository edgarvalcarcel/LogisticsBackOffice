using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Queries.GetClientById;
public record GetClientByIdQuery([ID(nameof(Client))] int Id) : IRequest<Client>; 
