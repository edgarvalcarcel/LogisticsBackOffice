using HotChocolate.Types.Relay;
using HotChocolate;
using LogisticsBackOffice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsBackOffice.Application.Services.Commands.ModifyService;
public record ModifyServiceCommand(
 [property: ID(nameof(Service))] int Id,
 Optional<string?> Name,
 Optional<bool?> IsReceivingService,
 Optional<bool?> IsProcessingService,
 Optional<bool?> IsWarehouseService,
 Optional<bool?> IsCleaningService) : IRequest<Service?>;
