namespace LogisticsBackOffice.Domain.Events.ClientEvents;
public class ClientUpdatedEvent : BaseEvent
{
    public ClientUpdatedEvent(Client client)
    {
        Client = client;
    }
    public Client Client { get; }
}