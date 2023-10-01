using LogisticsBackOffice.Application.Contacts;
using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Commands.ModifyOperator;

public class ModifyOperatorPayload : OperatorPayloadBase
{
    public ModifyOperatorPayload(Operator _operator)
        : base(_operator)
    {
    }
    public ModifyOperatorPayload(UserError error)
        : base(new[] { error })
    {
    }
}
