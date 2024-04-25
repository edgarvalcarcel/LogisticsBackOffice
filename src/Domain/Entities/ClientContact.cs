namespace LogisticsBackOffice.Domain.Entities;
public class ClientContact : BaseIdEntity
{
    public int ClientId { get; set; }
    public virtual Client? Client { get; set; }
    public int ContactId { get; set; }
    public virtual Contact? Contact { get; set; }
}
