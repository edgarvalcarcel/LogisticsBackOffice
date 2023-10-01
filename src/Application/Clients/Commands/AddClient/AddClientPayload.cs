using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Clients.Commands.AddClient;

public class AddClientPayload : ProjectPayloadBase
{
    public AddClientPayload(Client client)
        : base(client)
    {
    }

    public AddClientPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}