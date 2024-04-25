namespace LogisticsBackOffice.Domain.Events.WorkOrderEvents;
public class WorkOrderCreatedEvent : BaseEvent
{
    public WorkOrderCreatedEvent(WorkOrder workOrder)
    {
        WorkOrder = workOrder;
    }
    public WorkOrder WorkOrder { get; }
}
