namespace LogisticsBackOffice.Application.Responses;
public class WorkOrderDetailDto
{
    public int WorkerId { get; init; }
    public virtual WorkerDto? Worker { get; init; }
    public decimal HoursAmount { get; init; }
    public DateTime? ScheduledStartDate { get; init; }
    public DateTime? ScheduledEndDate { get; init; }
    public DateTime? ActualStartDate { get; init; }
    public DateTime? ActualEndDate { get; init; }
    public string? Notes { get; init; }
    public bool? ReportToStaff { get; init; }
    public int? StaffId { get; init; }
    public virtual ContactDto? Staff { get; init; }
    public int? PriorityId { get; init; }
    public string? WorkerSignature { get; init; }
}
