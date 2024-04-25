using LogisticsBackOffice.Domain.Events.WorkOrderEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LogisticsBackOffice.Application.WorkOrders.Events;
public class WorkOrderUpdatedEventHandler : INotificationHandler<WorkOrderUpdatedEvent>
{
    private readonly ILogger<WorkOrderUpdatedEventHandler> _logger;
    public WorkOrderUpdatedEventHandler(ILogger<WorkOrderUpdatedEventHandler> logger)
    {
        _logger = logger;
    }
    public Task Handle(WorkOrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("BackOffice Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}