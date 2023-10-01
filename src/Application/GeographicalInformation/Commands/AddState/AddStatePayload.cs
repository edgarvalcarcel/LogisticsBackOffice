using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.GeographicalInformation.Commands.AddState;

public class AddStatePayload : StatePayloadBase
{
    public AddStatePayload(State state)
        : base(state)
    {
    }

    public AddStatePayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
