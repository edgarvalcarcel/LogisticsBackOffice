using LogisticsBackOffice.Domain.Events.WorkOrderEvents;
namespace LogisticsBackOffice.Domain.Entities;
public class WorkOrder : BaseIdEntity
{
    public int ProjectId { get; set; }
    public virtual Project? Project { get; set; }
    public int ProjectDetailId { get; set; }
    public virtual ProjectDetail? ProjectDetail { get; set; }
    public int ServiceId { get; set; }
    public virtual Service? Service { get; set; }
    public decimal HoursAmount { get; set; }
    public DateTime? ScheduledStartDate { get; set; }
    public DateTime? ScheduledEndDate { get; set; }
    public DateTime? ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public bool? ReportToStaff { get; set; }
    public int? StaffId { get; set; }
    public virtual Contact? Staff { get; set; }
    public int? StatusId { get; set; }
    public virtual Status? Status { get; set; }
    public IList<WorkOrderDetail> WorkOrderDetail { get; set; } = [];
    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new WorkOrderCreatedEvent(this));
            }
            else AddDomainEvent(new WorkOrderUpdatedEvent(this));
            _done = value;
        }
    }
}
