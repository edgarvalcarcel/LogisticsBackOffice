using LogisticsBackOffice.Application.Projects.Queries.GetProjectById;
using LogisticsBackOffice.Application.Projects.Queries.GetProjects;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
namespace LogisticsBackOffice.GraphQL.Queries.Projects;
[QueryType]
public class ProjectQuery
{
    [UseProjection]
    [HotChocolate.Data.UseSingleOrDefault]
    public async Task<ProjectDto?> GetProject(int clientId, [Service] IMediator mediator)
    {
        var result = await mediator.Send(new GetProjectByIdQuery(clientId));
        return result;
    }
    [UseProjection]
    [HotChocolate.Data.UseSorting]
    [HotChocolate.Data.UseFiltering]
    public async Task<IList<ProjectDto>> GetProjects([Service(ServiceKind.Synchronized)] IMediator mediator)
    {
        return await mediator.Send(new GetProjectsQuery());
    }
}
