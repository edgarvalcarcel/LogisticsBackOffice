using LogisticsBackOffice.Application.Contacts;
using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Operators.Commands.AddOperator;
public class AddOperatorPayload : OperatorPayloadBase
{
    public AddOperatorPayload(Operator _operator)
        : base(_operator)
    {
    }

    public AddOperatorPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
