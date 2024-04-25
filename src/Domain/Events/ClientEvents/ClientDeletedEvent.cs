namespace LogisticsBackOffice.Domain.Events.ClientEvents;
public class ClientDeletedEvent : BaseEvent
{
    public ClientDeletedEvent(Client client)
    {
        Client = client;
    }
    public Client Client { get; }
}
