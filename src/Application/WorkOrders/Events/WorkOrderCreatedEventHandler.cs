using LogisticsBackOffice.Domain.Events.WorkOrderEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsBackOffice.Application.WorkOrders.Events;
public class WorkOrderCreatedEventHandler : INotificationHandler<WorkOrderCreatedEvent>
{
    private readonly ILogger<WorkOrderCreatedEventHandler> _logger;
    public WorkOrderCreatedEventHandler(ILogger<WorkOrderCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(WorkOrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("BackOffice Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}