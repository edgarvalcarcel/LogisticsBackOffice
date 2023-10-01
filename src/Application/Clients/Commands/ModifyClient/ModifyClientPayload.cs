using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Clients.Commands.ModifyClient;

public class ModifyClientPayload : ProjectPayloadBase
{
    public ModifyClientPayload(Client client)
        : base(client)
    {
    }

    public ModifyClientPayload(UserError error)
        : base(new[] { error })
    {
    }
}