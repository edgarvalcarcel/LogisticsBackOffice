using HotChocolate;
using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Operators.Commands.ModifyOperator;

public record ModifyOperatorCommand(
[property: ID(nameof(Operator))] int Id,
    Optional<string?> Title,
    Optional<string?> FullName,
    Optional<string?> FirstName,
    Optional<string?> LastName,
    Optional<string?> Email,
    Optional<string?> Cellphone,
    Optional<string?> AdditionalInfo,
    Optional<string?> Role,
    Optional<int> GeographicalnfoId,
    Optional<int> UserId) : IRequest<Operator?>;


