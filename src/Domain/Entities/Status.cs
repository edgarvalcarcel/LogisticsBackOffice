namespace LogisticsBackOffice.Domain.Entities;
public class Status
{
    public int Id { get; set; }
    public string? Entity { get; set; }
    public string? Name { get; set; }
    public int? Order { get; set; }
    public bool IsEnabled { get; set; }
    public string? Description { get; set; }
}
