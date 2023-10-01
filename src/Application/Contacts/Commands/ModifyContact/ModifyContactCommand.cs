using HotChocolate;
using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Contacts.Commands.ModifyContact;

public record ModifyContactCommand(
[property: ID(nameof(Contact))] int Id,
    Optional<string?> Title,
    Optional<string?> FullName,
    Optional<string?> FirstName,
    Optional<string?> LastName,
    Optional<string?> Suffix,
    Optional<string?> Email,
    Optional<string?> Cellphone,
    Optional<string?> AdditionalInfo,
    Optional<string?> Role) : IRequest<Contact?>;
