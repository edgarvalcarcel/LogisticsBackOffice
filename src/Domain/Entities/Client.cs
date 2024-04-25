using LogisticsBackOffice.Domain.Events.ClientEvents;

namespace LogisticsBackOffice.Domain.Entities;
public class Client : BaseIdEntity
{
    public string? Title { get; set; }
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Suffix { get; set; }
    public string? Email { get; set; }
    public string? Cellphone { get; set; }
    public string? AdditionalInfo { get; set; }
    public int GeographicalInfoId { get; set; }
    public virtual GeographicalInfo? GeographicalInfo { get; set; }
    public IList<ClientContact> ClientContact { get; set; } = [];

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && _done == false)
            {
                AddDomainEvent(new ClientCreatedEvent(this));
            }
            else AddDomainEvent(new ClientUpdatedEvent(this));

            _done = value;
        }
    }
}
