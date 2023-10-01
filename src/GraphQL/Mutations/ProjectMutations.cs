using LogisticsBackOffice.Application.Projects.Commands.AddProject;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
[ExtendObjectType(OperationTypeNames.Mutation)]
public class ProjectMutations
{
    public async Task<AddProjectPayload> AddProjectAsync(
    AddProjectCommand input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        var _operator = await mediator.Send(input, cancellationToken);
        return new AddProjectPayload(_operator);
    }
}
