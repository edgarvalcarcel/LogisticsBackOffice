using LogisticsBackOffice.Application.Projects.Queries.GetProjectById;
using LogisticsBackOffice.Application.Projects.Queries.GetProjects;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Queries;
[ExtendObjectType(OperationTypeNames.Query)]
public class ProjectQueries
{
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<IQueryable<Project>> GetProjectsAsync(
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetProjectsQuery(), cancellationToken);
    }
    [UsePaging]
    [UseProjection]
    [HotChocolate.Data.UseFiltering]
    [HotChocolate.Data.UseSorting]
    public async Task<Project> GetProjectByIdAsync(
        GetProjectByIdQuery input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }
}
