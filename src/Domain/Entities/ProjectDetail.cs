namespace LogisticsBackOffice.Domain.Entities;
public class ProjectDetail : BaseIdEntity
{
    public int ProjectId { get; set; }
    public virtual Project? Project { get; set; }
    public int ServiceId { get; set; }
    public virtual Service? Service { get; set; }
    public decimal Duration { get; set; }
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }
}
