using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Operators;

public class OperatorPayloadBase : Payload
{
    protected OperatorPayloadBase(Operator _operator)
    {
        Operator = _operator;
    }

    protected OperatorPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
    public Operator? Operator;
}
