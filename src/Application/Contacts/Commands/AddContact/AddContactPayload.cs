using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Contacts.Commands.AddContact;

public class AddContactPayload : ContactPayloadBase
{
    public AddContactPayload(Contact client)
        : base(client)
    {
    }

    public AddContactPayload(IReadOnlyList<UserError> errors)
        : base(errors)
    {
    }
}
