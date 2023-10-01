using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Projects.Commands.AddProject;
public class AddProjectPayload : ProjectPayloadBase
{
    public AddProjectPayload(Project project)
        : base(project)
    {
    }

    public AddProjectPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
