using AutoMapper;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using MediatR;

namespace LogisticsBackOffice.Application.Services.Commands.Modify;
public record ModifyServiceCommand : IRequest<ModifyServicePayload>
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public decimal Rate { get; init; }
    public int? ServiceTypeId { get; init; }
}
public record ModifyServicePayload(ServiceDto? Service);
public class ModifyServiceCommandHandler(IServiceRepository serviceRepository,
    IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<ModifyServiceCommand, ModifyServicePayload>
{
    public async Task<ModifyServicePayload> Handle(ModifyServiceCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var entityServiceExist = await serviceRepository.GetServiceByIdAsync(request.Id);
        if (entityServiceExist is null) return new ModifyServicePayload(mapper.Map<ServiceDto>(entityServiceExist));

        entityServiceExist = mapper.Map<Service>(request);

        serviceRepository.UpdateServiceAsync(entityServiceExist);
        await unitOfWork.Commit();

        return new ModifyServicePayload(mapper.Map<ServiceDto>(entityServiceExist));
    }
}