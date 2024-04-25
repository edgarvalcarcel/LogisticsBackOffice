using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Responses;
public class WorkOrderDto
{
    public int Id { get; init; }
    public int ProjectId { get; init; }
    public virtual ProjectDto? Project { get; init; }
    public int ProjectDetailId { get; init; }
    public virtual ProjectDetailDto? ProjectDetail { get; init; }
    public int ServiceId { get; init; }
    public virtual ServiceDto? Service { get; init; }
    public decimal HoursAmount { get; init; }
    public DateTime? ScheduledStartDate { get; init; }
    public DateTime? ScheduledEndDate { get; init; }
    public DateTime? ActualStartDate { get; init; }
    public DateTime? ActualEndDate { get; init; }
    public bool? ReportToStaff { get; init; }
    public int? StaffId { get; init; }
    public virtual Contact? Staff { get; init; }
    public int? StatusId { get; init; }
    public virtual Status? Status { get; init; }
    public IList<WorkOrderDetailDto> WorkOrderDetail { get; init; } = [];
}
