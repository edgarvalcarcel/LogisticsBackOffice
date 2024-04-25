using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.Clients.Commands.Create;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Domain.Entities;
using ValidationException = LogisticsBackOffice.Application.Common.Exceptions.ValidationException;

namespace Application.FunctionalTests.Clients;

public class CreatClientTests : BaseTestFixture
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

        var command = new CreateClientCommand()
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

        var command = new CreateClientCommand
        {
            Title = "Mr.",
            FirstName = fake.Name.FirstName(),
            LastName = fake.Name.LastName(),
            Suffix = "Ph.D",
            Email = fake.Person.Email.ToLower(),
            Cellphone = fake.Phone.PhoneNumber(),
            AdditionalInfo = " Information ",
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

        var command = new CreateClientCommand
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
    public async Task ShouldCreateClient()
    {
        Faker fake = new();
        var address1 = fake.Address.StreetAddress();
        var address2 = fake.Address.BuildingNumber();
        var city = fake.Address.City();
        var postalcode = fake.Address.ZipCode();
        var locationName = fake.Address.County() + "Store";
        var phoneNumber = fake.Phone.PhoneNumber();

        var command = new CreateClientCommand
        {
            Title = "Mr.",
            FirstName = fake.Name.FirstName(),
            LastName = fake.Name.LastName(),
            Suffix = "Ph.D",
            Email = fake.Person.Email.ToLower(),
            Cellphone = fake.Phone.PhoneNumber(),
            AdditionalInfo = " Information ",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        command.GeographicalInfo.StateId = 9;
        command.FullName = string.Concat(command.FirstName, " ", command.LastName);
        var payload = await Testing.SendAsync(command);
        var fakeClient = await Testing.FindAsync<Client>(payload.Client.Id);

        fakeClient.Should().NotBeNull();
        fakeClient!.FirstName.Should().Be(command.FirstName);
        fakeClient!.LastName.Should().Be(command.LastName);
        fakeClient!.Email.Should().Be(command.Email);
        fakeClient!.Cellphone.Should().Be(command.Cellphone);
    }
}