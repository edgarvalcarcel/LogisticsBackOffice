namespace LogisticsBackOffice.Domain.Entities;
public class Worker : BaseIdEntity
{
    public string? Title { get; set; }
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Cellphone { get; set; }
    public string? Role { get; set; }
    public string? AdditionalInfo { get; set; }
    public int GeographicalInfoId { get; set; }
    public virtual required GeographicalInfo? GeographicalInfo { get; set; }
    public int? UserId { get; set; }
}
