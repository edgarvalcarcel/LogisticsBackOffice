namespace LogisticsBackOffice.Domain.Entities;
public class Project : BaseIdEntity
{
    public int ClientId { get; set; }
    public virtual Client? Client { get; set; }
    public DateTime? ReceivingDate { get; set; }
    public DateTime? ProcessingDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? TotalReceivedPackages { get; set; }
    public int? TotalWorkers { get; set; }
    public string? Sidemark { get; set; }
    public int? ContactId { get; set; }
    public virtual Contact? Contact { get; set; }
    public bool? DeclaredValueInsurace { get; set; }
    public decimal? Amount { get; set; }
    public string? InspectionNotes { get; set; }
    public bool? ReplaytoEmail { get; set; }
    public string? EmailSent { get; set; }
    public int? GeographicalInfoId { get; set; }
    public virtual GeographicalInfo? GeographicalInfo { get; set; }
    public int? CourierCompanyId { get; set; }
    public virtual CourierCompany? CourierCompany { get; set; }
    public string? DriverName { get; set; }
    public string? ShippingNumber { get; set; }
    public string? ShipperOrigin { get; set; }
    public string? ProjectQRGenerated { get; set; }
    public IList<ProjectDetail> ProjectDetail { get; set; } = [];
    public int? StatusId { get; set; }
    public virtual Status? Status { get; set; }
    public bool Done { get; set; }
    //{
    //    if (value && !_done)
    //    {
    //        AddDomainEvent(new ProjectCreatedEvent(this));
    //    }
    //    else AddDomainEvent(new ProjectUpdatedEvent(this));

    //    _done = value;
    //}
}
