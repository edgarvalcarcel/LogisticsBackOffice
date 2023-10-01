using LogisticsBackOffice.Application.WorkOrders.Commands.AddWorkOrder;
using LogisticsBackOffice.Application.WorkOrders.Commands.ModifyWorkOrder;
using LogisticsBackOffice.Domain.Common;
using MediatR;

namespace LogisticsBackOffice.GraphQL.Mutations;
[ExtendObjectType(OperationTypeNames.Mutation)]
public class WorkOrderMutations
{
    public async Task<AddWorkOrderPayload> AddWorkOrderAsync(
    AddWorkOrderCommand input,
    [Service] IMediator mediator,
    CancellationToken cancellationToken)
    {
        var workOrder = await mediator.Send(input, cancellationToken);

        return new AddWorkOrderPayload(workOrder);
    }

    public async Task<ModifyWorkOrderPayload> ModifyWorkOrderAsync(
     ModifyWorkOrderCommand input,
     [Service] IMediator mediator,
     CancellationToken cancellationToken)
    {
        if ( input.Id < 0)
            return new ModifyWorkOrderPayload(
                new UserError("Id cannot be null", "ID_NULL"));

        var workOrder = await mediator.Send(input, cancellationToken);

        if (workOrder is null)
            return new ModifyWorkOrderPayload(
                new UserError("WorkOrder with id not found.", "WORKORDER_NOT_FOUND"));

        return new ModifyWorkOrderPayload(workOrder);
    }
}
