using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.GeographicalInformation;

public class StatePayloadBase : Payload
{
    public StatePayloadBase(State state)
    {
        State = state;
    }
    public State? State { get; }

    protected StatePayloadBase(IReadOnlyList<UserError> errors) : base(errors)
    {
    }
}
