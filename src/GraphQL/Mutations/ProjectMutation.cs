using HotChocolate.Subscriptions;
using LogisticsBackOffice.Application.Projects.Commands.Create;
using LogisticsBackOffice.Application.Projects.Commands.Delete;
using LogisticsBackOffice.Application.Projects.Commands.Modify;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;

public record ProjectCreatedPayload(int ProjectId);

[MutationType]
public class ProjectMutation
{
    public async Task<CreateProjectPayload> CreateProject(CreateProjectCommand input, [Service] ISender sender, [Service] ITopicEventSender topicEventSender)
    {
        var result = await sender.Send(input);
        await topicEventSender.SendAsync(nameof(CreateProject), new ProjectCreatedPayload(result.Project.Id));
        return result;
    }
    public async Task<ModifyProjectPayload> ModifyProject(ModifyProjectCommand input, [Service] ISender sender)
    {
        return await sender.Send(input);
    }
    public async Task<DeleteProjectPayload> DeleteProject(DeleteProjectCommand input, [Service] ISender sender) => await sender.Send(input);
}
