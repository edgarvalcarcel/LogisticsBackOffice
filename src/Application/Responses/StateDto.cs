namespace LogisticsBackOffice.Application.Responses;
public class StateDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? StateCode { get; init; }
    public int CountryRegionId { get; init; }
    public virtual CountryRegionDto? CountryRegion { get; init; }
    public int TerritoryId { get; init; }
}
