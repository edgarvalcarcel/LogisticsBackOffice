using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Commands.Create;
public record CreateServiceCommand : IRequest<CreateServicePayload>
{
    public string? Name { get; init; }
    public decimal Rate { get; init; }
    public int? ServiceTypeId { get; init; }
}
public record CreateServicePayload(ServiceDto Service);
public class CreateServiceCommandHandler(IServiceRepository serviceRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateServiceCommand, CreateServicePayload>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IServiceRepository _serviceRepository = serviceRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateServicePayload> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        Common.Exceptions.ArgumentNullException.ThrowIfNull(request);
        var entity = _mapper.Map<Service>(request);
        await _serviceRepository.AddServiceAsync(entity);
        await _unitOfWork.Commit();
        return new CreateServicePayload(_mapper.Map<ServiceDto>(entity));
    }
}