using LogisticsBackOffice.Application.GeographicalInformation.Commands.AddState;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
[ExtendObjectType(OperationTypeNames.Mutation)]
public class StateMutations
{
    public async Task<AddStatePayload> AddStateAsync(
  AddStateCommand input,
  [Service] IMediator mediator,
  CancellationToken cancellationToken)
    {
        var state = await mediator.Send(input, cancellationToken);
        return new AddStatePayload(state);
    }
}
