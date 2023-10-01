using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Contacts
{
    public class ContactPayloadBase:Payload
    {
        public ContactPayloadBase(Contact contact)
        {
            Contact = contact;
        }
        public Contact? Contact { get; }

        protected ContactPayloadBase(IReadOnlyList<UserError> errors) : base(errors)
        {
        }
    }
}
