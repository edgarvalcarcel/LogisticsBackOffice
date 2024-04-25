using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.WorkOrders.Command.Create;
using LogisticsBackOffice.Application.WorkOrders.Command.Delete;
using LogisticsBackOffice.Domain.Entities;

namespace Application.FunctionalTests.WorkOrders;
public class DeleteWorkOrderTests : BaseTestFixture
{
    private readonly Faker _faker = new();
    [Test]
    public async Task ShouldDeleteWorkOrder()
    {
        // Current Id's from project detail table on QA Db
        int[] x = [3, 19, 37, 38, 39, 40, 102, 103];

        var random = new Random();
        var randomId = Convert.ToInt32(x[random.Next(10)]);

        var existProjectDetail = await Testing.FindAsync<ProjectDetail>(randomId);
        List<WorkOrderDetailDto> workOrderDetailItems = [];

        var limit = _faker.Random.Number(2);
        for (var i = 0; i <= limit; i++)
        {
            var item = new WorkOrderDetailDto
            {
                WorkerId = _faker.Random.Number(1002, 1014),
                HoursAmount = decimal.Round(_faker.Random.Decimal(200), 2, MidpointRounding.AwayFromZero),
                ScheduledStartDate = DateTime.Now.AddDays(1),
                ScheduledEndDate = DateTime.Now.AddDays(17),
                Notes = "notes per work order writen by the worker",
                ReportToStaff = true,
                StaffId = _faker.Random.Number(30, 39),
                PriorityId = 1,
                WorkerSignature = "url.com/signature.jpg"
            };
            workOrderDetailItems.Add(item);
        }
        var command = new CreateWorkOrderCommand()
        {
            ProjectId = existProjectDetail!.ProjectId,
            ProjectDetailId = existProjectDetail!.Id,
            ServiceId = existProjectDetail!.ServiceId,
            HoursAmount = _faker.Random.Number(5, 220),
            ScheduledStartDate = DateTime.Now.AddDays(1),
            ScheduledEndDate = DateTime.Now.AddDays(17),
            ReportToStaff = true,
            StaffId = _faker.Random.Number(30, 39),
            WorkOrderDetail = workOrderDetailItems
        };
        var payload = await Testing.SendAsync(command);
        var fakeWorkOrder = await Testing.FindAsync<WorkOrder>(payload.WorkOrder.Id);

        var objWorkOrder = await Testing.SendAsync(new DeleteWorkOrderCommand(fakeWorkOrder!.Id));
        objWorkOrder.Should().NotBeNull();
    }
}
