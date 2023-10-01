using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Commands.AddService;

public class AddServiceCommandHandler : IRequestHandler<AddServiceCommand, Service>
{
    private readonly IServiceRepository _repository;

    public AddServiceCommandHandler(IServiceRepository repository)
    {
        _repository = repository;
    }
    public async Task<Service> Handle(AddServiceCommand request, CancellationToken cancellationToken)
    {
        var service = new Service
        {
            Name = request.Name,
            IsReceivingService = request.IsReceivingService,
            IsProcessingService = request.IsProcessingService,
            IsWarehouseService = request.IsWarehouseService,
            IsCleaningService = request.IsCleaningService
        };

        await _repository.AddServiceAsync(service, cancellationToken);
        return service;
    }
}

