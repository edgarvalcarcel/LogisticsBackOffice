namespace LogisticsBackOffice.Domain.Events.ClientEvents;
public class ClientCreatedEvent : BaseEvent
{
    public ClientCreatedEvent(Client client)
    {
        Client = client;
    }
    public Client Client { get; }
}
