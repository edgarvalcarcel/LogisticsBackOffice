namespace LogisticsBackOffice.Domain.Entities;
public class State : BaseIdEntity
{
    public string? Name { get; set; }
    public string? StateCode { get; set; }
    public int CountryRegionId { get; set; }
    public virtual CountryRegion? CountryRegion { get; set; }
    public int TerritoryId { get; set; }
}
