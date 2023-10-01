using LogisticsBackOffice.Application.Services.Commands.AddService;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
[ExtendObjectType(OperationTypeNames.Mutation)]
public class ServiceMutations
{
    public async Task<AddServicePayload> AddServiceAsync(
     AddServiceCommand input,
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
    {
        var service = await mediator.Send(input, cancellationToken);
        return new AddServicePayload(service);
    }
}
