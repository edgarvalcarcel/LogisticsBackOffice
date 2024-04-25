namespace LogisticsBackOffice.Application.Responses;
public class WorkerDto
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Cellphone { get; init; }
    public string? Role { get; init; }
    public string? AdditionalInfo { get; init; }
    public int GeographicalInfoId { get; init; }
    public virtual GeographicalInfoDto? GeographicalInfo { get; init; }
    public int ProjectId { get; init; }
    public virtual required ProjectDto Project { get; init; }
    public int? UserId { get; init; }
}
