using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Responses;
public class ProjectDto
{
    public int Id { get; init; }
    public int ClientId { get; init; }
    public virtual ClientDto? Client { get; init; }
    public DateTime? ReceivingDate { get; init; }
    public DateTime? ProcessingDate { get; init; }
    public DateTime? EndDate { get; init; }
    public int? TotalReceivedPackages { get; init; }
    public int? TotalWorkers { get; init; }
    public string? Sidemark { get; init; }
    public int ContactId { get; init; }
    public virtual ContactDto? Contact { get; init; }
    public bool? DeclaredValueInsurace { get; init; }
    public decimal? Amount { get; init; }
    public string? InspectionNotes { get; init; }
    public bool? ReplaytoEmail { get; init; }
    public string? EmailSent { get; init; }
    public int? GeographicalInfoId { get; init; }
    public virtual GeographicalInfoDto? GeographicalInfo { get; init; }
    public int CourierCompanyId { get; init; }
    public virtual CourierCompanyDto? CourierCompany { get; init; }
    public string? DriverName { get; init; }
    public string? ShippingNumber { get; init; }
    public string? ShipperOrigin { get; init; }
    public string? ProjectQRGenerated { get; init; }
    public virtual ICollection<ProjectDetailDto>? ProjectDetail { get; init; }
    public int? StatusId { get; init; }
    public virtual Status? Status { get; init; }
}
