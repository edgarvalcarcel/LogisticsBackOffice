namespace LogisticsBackOffice.Domain.Events.ProjectEvents;
public class ProjectDetailUpdatedEvent : BaseEvent
{
    public ProjectDetailUpdatedEvent(ProjectDetail project)
    {
        Project = project;
    }
    public ProjectDetail Project { get; }
}
