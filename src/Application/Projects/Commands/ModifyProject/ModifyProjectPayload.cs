using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Projects.Commands.ModifyProject;

public class ModifyProjectPayload : ProjectPayloadBase
{
    public ModifyProjectPayload(Project project)
        : base(project)
    {
    }

    public ModifyProjectPayload(UserError error)
        : base(new[] { error })
    {
    }
}
