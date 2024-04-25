namespace LogisticsBackOffice.Domain.Events.ProjectEvents;
public class ProjectUpdatedEvent : BaseEvent
{
    public ProjectUpdatedEvent(Project project)
    {
        Project = project;
    }
    public Project Project { get; }
}