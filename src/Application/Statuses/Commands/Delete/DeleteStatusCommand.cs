using AutoMapper;
using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Application.Responses;
using MediatR;

namespace LogisticsBackOffice.Application.Statuses.Commands.Delete;
public record DeleteStatusCommand(int Id) : IRequest<DeleteStatusPayload>;
public record DeleteStatusPayload(StatusDto Status);
public class DeleteStatusCommandHandler(IStatusRepository statusRepository,
IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<DeleteStatusCommand, DeleteStatusPayload>
{
    public async Task<DeleteStatusPayload> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await statusRepository.GetStatusByIdAsync(request.Id) ?? throw new NotFoundException(nameof(StatusDto), request.Id);

        await statusRepository.DeleteStatusAsync(entity);
        await unitOfWork.Commit();
        return new DeleteStatusPayload(mapper.Map<StatusDto>(entity));
    }
}
