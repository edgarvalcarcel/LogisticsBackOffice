using LogisticsBackOffice.Application.GeographicalInformation.Commands.AddGeographicalInfo;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
[ExtendObjectType(OperationTypeNames.Mutation)]
public class GeographicalInfoMutations
{
    public async Task<AddGeographicalInfoPayload> AddContactAsync(
    AddGeographicalInfoCommand input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        var geographicalInfo = await mediator.Send(input, cancellationToken);
        return new AddGeographicalInfoPayload(geographicalInfo);
    }
}
