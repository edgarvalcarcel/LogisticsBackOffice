namespace LogisticsBackOffice.Application.Responses;
public class ClientContactDto
{
    public int ClientId { get; init; }
    public virtual ClientDto? Client { get; init; }
    public int ContactId { get; init; }
    public virtual ContactDto? Contact { get; init; }
}
