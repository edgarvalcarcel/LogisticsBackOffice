using LogisticsBackOffice.Domain.Common;
using LogisticsBackOffice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Services.Commands.ModifyService;

public class ModifyServicePayload : ServicePayloadBase
{
    public ModifyServicePayload(Service service)
        : base(service)
    {
    }
    public ModifyServicePayload(UserError error)
        : base(new[] { error })
    {
    }
}
