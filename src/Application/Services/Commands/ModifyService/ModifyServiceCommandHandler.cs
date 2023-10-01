using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Commands.ModifyService;

public class ModifyServiceCommandHandler : IRequestHandler<ModifyServiceCommand, Service?>
{
    private readonly IServiceRepository _repository;

    public ModifyServiceCommandHandler(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<Service?> Handle(ModifyServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await _repository.FindServiceByIdAsync(request.Id, cancellationToken);

        if (service is null) return service;

        if (request.Name.HasValue) service.Name = request.Name;
        if (request.IsReceivingService.HasValue) service.IsReceivingService = request.IsReceivingService;
        if (request.IsProcessingService.HasValue) service.IsProcessingService = request.IsProcessingService;
        if (request.IsWarehouseService.HasValue) service.IsWarehouseService = request.IsWarehouseService;
        if (request.IsCleaningService.HasValue) service.IsCleaningService = request.IsCleaningService;

        await _repository.UpdateServiceAsync(service, cancellationToken);
        return service;
    }
}