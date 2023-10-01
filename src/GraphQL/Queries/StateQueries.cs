using LogisticsBackOffice.Application.GeographicalInformation.Queries.GetStates;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]
public class StateQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<IQueryable<State>> GetStatesAsync(
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetStatesQuery(), cancellationToken);
    }
}
