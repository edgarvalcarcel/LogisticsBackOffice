using LogisticsBackOffice.GraphQL.Mutations;

namespace LogisticsBackOffice.GraphQL.Subscriptions;

[SubscriptionType]
public class Subscription
{
    [Subscribe]
    [Topic(nameof(ClientMutation.CreateClient))]
    public ClientCreatedPayload OnClientCreated([EventMessage] ClientCreatedPayload client)
    {
        return client;
    }

    [Topic(nameof(ProjectMutation.CreateProject))]
    public ProjectCreatedPayload OnProjectCreated([EventMessage] ProjectCreatedPayload project)
    {
        return project;
    }
}
