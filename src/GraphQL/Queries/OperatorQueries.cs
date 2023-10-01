using LogisticsBackOffice.Application.Operators.Queries.GetOperatorById;
using LogisticsBackOffice.Application.Operators.Queries.GetOperators;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]
public class OperatorQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<IQueryable<Operator>> GetOperatorsAsync(
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetOperatorsQuery(), cancellationToken);
    }
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<Operator> GetOperatorByIdAsync(
       GetOperatorByIdQuery input,
       [Service] IMediator mediator,
       CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
