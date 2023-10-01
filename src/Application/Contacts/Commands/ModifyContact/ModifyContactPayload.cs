using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Contacts.Commands.ModifyContact;

public class ModifyContactPayload : ContactPayloadBase
{
    public ModifyContactPayload(Contact contact)
        : base(contact)
    {
    }

    public ModifyContactPayload(UserError error)
        : base(new[] { error })
    {
    }
}
