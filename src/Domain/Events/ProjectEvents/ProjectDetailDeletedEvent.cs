namespace LogisticsBackOffice.Domain.Events.ProjectEvents;
public class ProjectDetailDeletedEvent : BaseEvent
{
    public ProjectDetailDeletedEvent(ProjectDetail project)
    {
        Project = project;
    }
    public ProjectDetail Project { get; }
}
