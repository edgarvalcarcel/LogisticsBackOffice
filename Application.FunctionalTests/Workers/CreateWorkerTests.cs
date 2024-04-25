using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.Workers.Commands.Create;
using ValidationException = LogisticsBackOffice.Application.Common.Exceptions.ValidationException;

namespace Application.FunctionalTests.Workers;
public class CreateWorkerTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        Faker faker = new();
        var address1 = faker.Address.StreetAddress();
        var address2 = faker.Address.BuildingNumber();
        var city = faker.Address.City();
        var postalcode = faker.Address.ZipCode();
        var locationName = faker.Address.County() + "store Test";
        var phoneNumber = faker.Phone.PhoneNumber();

        var command = new CreateWorkerCommand()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        await FluentActions.Invoking(() =>
            Testing.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldNotRequireAnyValidation()
    {
        Faker fake = new();
        ArgumentNullException.ThrowIfNull(fake);
        var address1 = fake.Address.StreetAddress();
        var address2 = fake.Address.BuildingNumber();
        var city = fake.Address.City();
        var postalcode = fake.Address.ZipCode();
        var locationName = fake.Address.County() + "Store";
        var phoneNumber = fake.Phone.PhoneNumber();

        var command = new CreateWorkerCommand
        {
            Title = "Mr.",
            Role = "Staff engineering.",
            FirstName = fake.Name.FirstName(),
            LastName = fake.Name.LastName(),
            FullName = fake.Name.FullName(),
            Suffix = "Ph.D",
            Email = fake.Person.Email.ToLower(),
            Cellphone = fake.Phone.PhoneNumber(),
            AdditionalInfo = " Information for creating worker testing ",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        command.GeographicalInfo.StateId = 9;
        await FluentActions.Invoking(() =>
            Testing.SendAsync(command)).Should().NotThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldRequireSomeValidations()
    {
        Faker fake = new();
        var address1 = "";
        var address2 = "";
        var city = "";
        var postalcode = "";
        var locationName = "";
        var phoneNumber = "";

        var command = new CreateWorkerCommand
        {
            Title = "",
            FirstName = "",
            LastName = "",
            Suffix = "",
            Email = "",
            Cellphone = "",
            AdditionalInfo = "",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        command.GeographicalInfo.StateId = 9;
        await FluentActions.Invoking(() =>
            Testing.SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateWorker()
    {
        Faker fake = new();
        var address1 = fake.Address.StreetAddress();
        var address2 = fake.Address.BuildingNumber();
        var city = fake.Address.City();
        var postalcode = fake.Address.ZipCode();
        var locationName = fake.Address.County() + "Store";
        var phoneNumber = fake.Phone.PhoneNumber();

        var command = new CreateWorkerCommand
        {
            Title = "Mr.",
            FirstName = fake.Name.FirstName(),
            LastName = fake.Name.LastName(),
            Role = "Ph.",
            Email = fake.Person.Email.ToLower(),
            Cellphone = fake.Phone.PhoneNumber(),
            AdditionalInfo = " Information for creating worker testing ",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        command.GeographicalInfo.StateId = 9;
        command.FullName = string.Concat(command.FirstName, " ", command.LastName);
        var payload = await Testing.SendAsync(command);
        //var fakeWorker = await Testing.FindAsync<Worker>(payload.Worker.Id);

        payload.Worker.Should().NotBeNull();
        payload.Worker!.FirstName.Should().Be(command.FirstName);
        payload.Worker!.LastName.Should().Be(command.LastName);
        payload.Worker!.Email.Should().Be(command.Email);
        payload.Worker!.Cellphone.Should().Be(command.Cellphone);
    }
}