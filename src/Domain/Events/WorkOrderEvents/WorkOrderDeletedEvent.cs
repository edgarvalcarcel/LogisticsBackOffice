namespace LogisticsBackOffice.Domain.Events.WorkOrderEvents;
public class WorkOrderDeletedEvent : BaseEvent
{
    public WorkOrderDeletedEvent(WorkOrder workOrder)
    {
        WorkOrder = workOrder;
    }
    public WorkOrder WorkOrder { get; }
}
