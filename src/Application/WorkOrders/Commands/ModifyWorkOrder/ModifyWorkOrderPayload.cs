using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.WorkOrders.Commands.ModifyWorkOrder;

public class ModifyWorkOrderPayload : WorkOrderPayloadBase
{
    public ModifyWorkOrderPayload(WorkOrder workOrder)
        : base(workOrder)
    {
    }

    public ModifyWorkOrderPayload(UserError error)
        : base(new[] { error })
    {
    }
}
