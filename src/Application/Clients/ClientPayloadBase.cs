using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Clients;

public class ProjectPayloadBase : Payload
{
    protected ProjectPayloadBase(Client client)
    {
        Client = client;
    }

    protected ProjectPayloadBase(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }

    public Client? Client { get; }
}