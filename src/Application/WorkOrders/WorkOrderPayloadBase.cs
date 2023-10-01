using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.WorkOrders;

public class WorkOrderPayloadBase : Payload
{
    protected WorkOrderPayloadBase(WorkOrder workOrder)
    {
        WorkOrder = workOrder;
    }

    protected WorkOrderPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public WorkOrder? WorkOrder { get; }
}
