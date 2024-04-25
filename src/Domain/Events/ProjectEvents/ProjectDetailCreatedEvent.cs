namespace LogisticsBackOffice.Domain.Events.ProjectEvents;
public class ProjectDetailCreatedEvent : BaseEvent
{
    public ProjectDetailCreatedEvent(ProjectDetail project)
    {
        Project = project;
    }
    public ProjectDetail Project { get; }
}
