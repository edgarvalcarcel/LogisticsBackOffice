using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.Projects.Commands.Create;
using LogisticsBackOffice.Application.Projects.Commands.Delete;
using LogisticsBackOffice.Application.Responses;

namespace Application.FunctionalTests.Projects;
public class DeleteProjectTests
{
    [Test]
    public async Task ShouldDeleteProject()
    {
        Faker faker = new();
        var address1 = faker.Address.StreetAddress();
        var address2 = faker.Address.BuildingNumber();
        var city = faker.Address.City();
        var postalcode = faker.Address.ZipCode();
        var locationName = faker.Address.County() + "store Test";
        var phoneNumber = faker.Phone.PhoneNumber();

        var contact = new ContactDto()
        {
            Title = "Mr.",
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Person.Email.ToLower(),
            Cellphone = faker.Phone.PhoneNumber(),
            AdditionalInfo = faker.Random.Chars(count: 20).ToString(),
            Role = "Tester Create Project"
        };
        contact.FullName = string.Concat(contact.FirstName, " ", contact.LastName);

        var clientObject = new ClientDto()
        {
            Id = 0,
            Title = "Mr.",
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Person.Email.ToLower(),
            Cellphone = faker.Phone.PhoneNumber(),
            AdditionalInfo = "Tester Create Project",
            Suffix = "III",
            GeographicalInfoId = 0,
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
            {
                StateId = 19
            }
        };
        clientObject.FullName = string.Concat(clientObject.FirstName, " ", clientObject.LastName);

        var geographicalInfoObject = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        {
            StateId = 19
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
                Amount = decimal.Round(faker.Random.Decimal(2000), 2, MidpointRounding.AwayFromZero),
            };
            projectDetailItems.Add(item);
        }
        ArgumentNullException.ThrowIfNull(faker);
        var command = new CreateProjectCommand()
        {
            Contact = contact,
            Client = clientObject,
            GeographicalInfo = geographicalInfoObject,
            //ClientId = faker.Random.Number(10),
            EndDate = DateTime.Now.AddDays(faker.Random.Number(60)),
            TotalReceivedPackages = faker.Random.Number(200),
            Sidemark = "Medium",
            DeclaredValueInsurace = faker.Random.Bool(),
            Amount = faker.Random.Number(2000),
            InspectionNotes = "Inspection is Ok",
            ReplaytoEmail = faker.Random.Bool(),
            EmailSent = faker.Person.Email,
            CourierCompanyId = faker.Random.Number(1, 17),
            DriverName = faker.Person.FullName,
            ShippingNumber = faker.Random.Number(20000).ToString(),
            ShipperOrigin = faker.Random.Number(30000).ToString(),
            ProjectDetail = projectDetailItems
        };

        var projectCreated = await Testing.SendAsync(command);

        var objProject = await Testing.SendAsync(new DeleteProjectCommand(projectCreated.Project.Id));
        objProject.Should().NotBeNull();
    }
}
