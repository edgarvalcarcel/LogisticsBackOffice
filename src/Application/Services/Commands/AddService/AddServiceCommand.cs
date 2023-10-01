using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Commands.AddService;
public record AddServiceCommand(
    string? Name,
    bool? IsReceivingService,
    bool? IsProcessingService,
    bool? IsWarehouseService,
    bool? IsCleaningService) : IRequest<Service>;



 
