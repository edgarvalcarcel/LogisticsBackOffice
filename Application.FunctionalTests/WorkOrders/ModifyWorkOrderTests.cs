using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.WorkOrders.Command.Modify;
using LogisticsBackOffice.Domain.Entities;

namespace Application.FunctionalTests.WorkOrders;
public class ModifyWorkOrderTests
{
    private readonly Faker _faker = new();
    [Test]
    public async Task ShouldModifyWorkOrder()
    {

        int[] randomWorkOrderList = [3, 5, 7, 9, 10, 14, 18];
        var randomWorkOrder = new Random();

        List<WorkOrderDetailDto> workOrderDetailItems = [];
        int[] randomWorkerId = [3,
                        1002,
                        1003,
                        1004,
                        1005,
                        1006,
                        1007,
                        1008,
                        1009,
                        1010,
                        1011,
                        1012,
                        1013,
                        1014,
                        1016,
                        1017];

        var randomW = new Random();
        var limit = _faker.Random.Number(3);
        for (var i = 0; i <= limit; i++)
        {
            var item = new WorkOrderDetailDto
            {
                WorkerId = Convert.ToInt32(randomWorkerId[randomW.Next(10)]),
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

        var workOrderRandom = Convert.ToInt32(randomWorkOrderList[randomWorkOrder.Next(10)]);

        var existWorkOrder = await Testing.FindAsync<WorkOrder>(workOrderRandom);
        var modifyCommand = new ModifyWorkOrderCommand()
        {
            Id = existWorkOrder!.Id,
            ProjectId = existWorkOrder!.ProjectId,
            ProjectDetailId = existWorkOrder!.ProjectDetailId,
            ServiceId = existWorkOrder!.ServiceId,
            HoursAmount = _faker.Random.Number(5, 220),
            ScheduledStartDate = DateTime.Now.AddDays(1),
            ScheduledEndDate = DateTime.Now.AddDays(17),
            ReportToStaff = true,
            StaffId = _faker.Random.Number(30, 39),
            WorkOrderDetail = workOrderDetailItems
        };

        var workOrderModified = await Testing.SendAsync(modifyCommand);

        workOrderModified.Should().NotBeNull();
    }
}
