using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Projects;

public class ProjectPayloadBase : Payload
{
    protected ProjectPayloadBase(Project project)
    {
        Project = project;
    }

    protected ProjectPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
    public Project? Project { get; }
}