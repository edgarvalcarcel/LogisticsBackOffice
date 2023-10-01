using LogisticsBackOffice.Domain.Entities;
using HotChocolate;
using HotChocolate.Types.Relay;
using MediatR;

namespace LogisticsBackOffice.Application.Clients.Commands.ModifyClient;

public record ModifyClientCommand(
    [property: ID(nameof(Client))] int Id,
    Optional<string?> Title,
    Optional<string?> FullName,
    Optional<string?> FirstName,
    Optional<string?> LastName,
    Optional<string> Suffix,
    Optional<string?> Email,
    Optional<string?> Cellphone,
    Optional<GeographicalInfo?> Geographicalnfo
    ) : IRequest<Client?>;