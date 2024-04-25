using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;
namespace LogisticsBackOffice.Application.Services.Commands.Delete;
public record DeleteServiceCommand(int Id) : IRequest<DeleteServicePayload>;
public record DeleteServicePayload(ServiceDto Service);
public class DeleteServiceCommandHandler(IServiceRepository serviceRepository,
IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteServiceCommand, DeleteServicePayload>
{
    public async Task<DeleteServicePayload> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await serviceRepository.GetServiceByIdAsync(request.Id) ?? throw new NotFoundException(nameof(ServiceDto), request.Id);

        await serviceRepository.DeleteServiceAsync(entity);
        await unitOfWork.Commit();
        return new DeleteServicePayload(mapper.Map<ServiceDto>(entity));
    }
}

