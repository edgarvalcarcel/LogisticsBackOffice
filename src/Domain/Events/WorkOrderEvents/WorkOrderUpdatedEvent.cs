namespace LogisticsBackOffice.Domain.Events.WorkOrderEvents;
public class WorkOrderUpdatedEvent : BaseEvent
{
    public WorkOrderUpdatedEvent(WorkOrder workOrder)
    {
        WorkOrder = workOrder;
    }
    public WorkOrder WorkOrder { get; }
}