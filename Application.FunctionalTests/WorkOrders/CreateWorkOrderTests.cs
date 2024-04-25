using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.WorkOrders.Command.Create;
using LogisticsBackOffice.Domain.Entities;
using ValidationException = LogisticsBackOffice.Application.Common.Exceptions.ValidationException;

namespace Application.FunctionalTests.WorkOrders;
public class CreateWorkOrderTests : BaseTestFixture
{
    private readonly Faker _faker = new();
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateWorkOrderCommand()
        {
            ProjectId = _faker.Random.Number(1002, 1017),
            ProjectDetailId = 37,
            //ServiceId = 12,
            HoursAmount = 20,
            ScheduledStartDate = DateTime.Now,
            ScheduledEndDate = DateTime.Now.AddDays(17),
        };
        await FluentActions.Invoking(() =>
            Testing.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldNotRequireAnyValidation()
    {
        List<WorkOrderDetailDto> detailOrderList = [];
        var limit = _faker.Random.Number(3);
        for (var i = 0; i <= limit; i++)
        {
            var itemDetailOrder = new WorkOrderDetailDto
            {
                WorkerId = _faker.Random.Number(1002, 1017),
                HoursAmount = _faker.Random.Number(10, 120),
                ScheduledStartDate = DateTime.Now.AddDays(_faker.Random.Number(7)),
                ScheduledEndDate = DateTime.Now.AddDays(_faker.Random.Number(60)),
                Notes = _faker.Lorem.Paragraph(1)[20..],
                ReportToStaff = true,
                StaffId = _faker.Random.Number(30, 39),
                PriorityId = 1,
                WorkerSignature = _faker.Internet.Url()
            };
            detailOrderList.Add(itemDetailOrder);
        }
        var command = new CreateWorkOrderCommand()
        {
            ProjectId = 19,
            ProjectDetailId = 37,
            ServiceId = 12,
            HoursAmount = 20,
            ScheduledStartDate = DateTime.Now,
            ScheduledEndDate = DateTime.Now.AddDays(17),
            ReportToStaff = true,
            StaffId = 10,
            WorkOrderDetail = detailOrderList
        };
        await FluentActions.Invoking(() =>
            Testing.SendAsync(command)).Should().NotThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateWorkOrder()
    {
        // Current Id's from project detail table on QA Db
        int[] x = 
            [102,
            103,
            107,
            108,
            109,
            110,
            111,
            112,
            113,
            114,
            115,
            116,
            117,
            122,
            123,
            124,
            125,
            126,
            127,
            131,
            132,
            133,
            134,
            135,
            136,
            137,
            138,
            139,
            140,
            141,
            142,
            143,
            144,
            145,
            146,
            147];

        var random = new Random();
        var randomId = Convert.ToInt32(x[random.Next(10)]);

        var existProjectDetail = await Testing.FindAsync<ProjectDetail>(randomId);
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

        fakeWorkOrder.Should().NotBeNull();
    }
}
