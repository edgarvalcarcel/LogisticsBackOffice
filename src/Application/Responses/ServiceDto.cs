namespace LogisticsBackOffice.Application.Responses;
public class ServiceDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public decimal Rate { get; init; }
    public int? ServiceTypeId { get; init; }
}
