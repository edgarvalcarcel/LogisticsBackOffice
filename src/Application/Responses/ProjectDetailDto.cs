namespace LogisticsBackOffice.Application.Responses;
public class ProjectDetailDto
{
    public int ServiceId { get; init; }
    public virtual ServiceDto? Service { get; init; }
    public decimal Duration { get; init; }
    public decimal Rate { get; init; }
    public decimal Amount { get; init; }
}
