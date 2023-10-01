using HotChocolate.Types.Relay;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Services.Queries.GetServiceById;

public record GetServiceByIdQuery([ID(nameof(Service))] int Id) : IRequest<Service>;
