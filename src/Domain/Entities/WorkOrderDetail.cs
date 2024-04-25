namespace LogisticsBackOffice.Domain.Entities;
public class WorkOrderDetail : BaseIdEntity
{
    public int WorkOrderId { get; set; }
    public virtual WorkOrder? WorkOrder { get; set; }
    public int WorkerId { get; set; }
    public virtual Worker? Worker { get; set; }
    public decimal HoursAmount { get; set; }
    public DateTime? ScheduledStartDate { get; set; }
    public DateTime? ScheduledEndDate { get; set; }
    public DateTime? ActualStartDate { get; init; }
    public DateTime? ActualEndDate { get; set; }
    public string? Notes { get; set; }
    public bool? ReportToStaff { get; set; }
    public int? StaffId { get; set; }
    public virtual Contact? Staff { get; set; }
    public int? PriorityId { get; set; }
    public string? WorkerSignature { get; set; }
}
