namespace LogisticsBackOffice.Domain.Entities;
public class Service : BaseIdEntity
{
    public string? Name { get; set; }
    public decimal Rate { get; init; }
    public int? ServiceTypeId { get; set; }
    public virtual ServiceType? ServiceType { get; set; }
}
