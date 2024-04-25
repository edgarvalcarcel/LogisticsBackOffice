using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Projects.Commands.Modify;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
namespace Application.FunctionalTests.Projects;
public class ModifyProjectTest : BaseTestFixture
{
    [Test]
    public async Task ShouldModifyProject()
    {

        Faker faker = new();
        var address1 = faker.Address.StreetAddress();
        var address2 = faker.Address.BuildingNumber();
        var city = faker.Address.City();
        var postalcode = faker.Address.ZipCode();
        var locationName = faker.Address.County() + "store Test";
        var phoneNumber = faker.Phone.PhoneNumber();

        var geographicalInfoObject = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        {
            StateId = 19,
            Id = 0
        };

        List<ProjectDetailDto> projectDetailItems = [];
        var limit = faker.Random.Number(1, 3);
        HashSet<int> uniqueService = [];
        for (var i = 0; i <= limit; i++)
        {
            uniqueService.Add(faker.Random.Number(7, 16));
        }
        // Converting HashSet to Array 
        var hashSetArray = new int[uniqueService.Count];
        uniqueService.CopyTo(hashSetArray);

        for (var i = 0; i < hashSetArray.Length; i++)
        {
            var item = new ProjectDetailDto
            {
                ServiceId = hashSetArray[i],
                Rate = decimal.Round(faker.Random.Decimal(200), 2, MidpointRounding.AwayFromZero),
                Duration = decimal.Round(faker.Random.Decimal(200), 2, MidpointRounding.AwayFromZero),
                Amount = decimal.Round(faker.Random.Decimal(500), 2, MidpointRounding.AwayFromZero),
            };
            projectDetailItems.Add(item);
        }
        ArgumentNullException.ThrowIfNull(faker);

        var existProject = await Testing.FindAsync<Project>(45);


        var modifyCommand = new ModifyProjectCommand()
        {
            Id = existProject!.Id,
            ContactId = (int)existProject?.ContactId,
            ClientId = (int)existProject?.ClientId,
            GeographicalInfo = geographicalInfoObject,
            GeographicalInfoId = 0,
            EndDate = DateTime.Now.AddDays(faker.Random.Number(60)),
            TotalReceivedPackages = faker.Random.Number(200),
            Sidemark = "Medium",
            DeclaredValueInsurace = faker.Random.Bool(),
            Amount = faker.Random.Number(2000),
            InspectionNotes = "Inspection is Ok, modified",
            ReplaytoEmail = faker.Random.Bool(),
            EmailSent = faker.Person.Email,
            CourierCompanyId = faker.Random.Number(17),
            DriverName = faker.Person.FullName,
            ShippingNumber = faker.Random.Number(20000).ToString(),
            ShipperOrigin = faker.Random.Number(30000).ToString(),
            ProjectDetail = projectDetailItems,
            StatusId = 10
        };
        var projectModified = await Testing.SendAsync(modifyCommand);

        projectModified.Should().NotBeNull();

        projectModified.Project.Contact!.FirstName.Should().Be(modifyCommand.Contact.FirstName);
        projectModified.Project.Contact!.LastName.Should().Be(modifyCommand.Contact.LastName);

        projectModified.Project.GeographicalInfo!.AddressLine1.Should().Be(modifyCommand.GeographicalInfo.AddressLine1);
        projectModified.Project.GeographicalInfo!.AddressLine2.Should().Be(modifyCommand.GeographicalInfo.AddressLine2);
        projectModified.Project.DriverName.Should().Be(modifyCommand.DriverName);
    }
}
