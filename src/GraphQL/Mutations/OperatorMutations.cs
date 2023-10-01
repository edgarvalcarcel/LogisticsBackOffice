using LogisticsBackOffice.Application.Operators.Commands.AddOperator;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
[ExtendObjectType(OperationTypeNames.Mutation)]
public class OperatorMutations
{
    public async Task<AddOperatorPayload> AddOperatorAsync(
    AddOperatorCommand input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        var _operator = await mediator.Send(input, cancellationToken);
        return new AddOperatorPayload(_operator);
    }
}
