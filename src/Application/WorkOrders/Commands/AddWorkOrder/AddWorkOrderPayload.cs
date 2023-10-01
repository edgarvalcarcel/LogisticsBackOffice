using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.WorkOrders.Commands.AddWorkOrder;

public class AddWorkOrderPayload : WorkOrderPayloadBase
{
    public AddWorkOrderPayload(WorkOrder client)
        : base(client)
    {
    }

    public AddWorkOrderPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
