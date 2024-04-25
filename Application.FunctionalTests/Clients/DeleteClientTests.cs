using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.Clients.Commands.Create;
using LogisticsBackOffice.Application.Clients.Commands.Delete;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.Responses;

namespace Application.FunctionalTests.Clients;
public class DeleteClientTests
{
    [Test]
    public async Task ShouldDeleteClient()
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
            Cellphone = "(312) 720 9050",
            AdditionalInfo = " Information",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        command.GeographicalInfo.StateId = 10;
        command.FullName = string.Concat(command.FirstName, " ", command.LastName);
        var clientCreated = await Testing.SendAsync(command);

        var objClient = await Testing.SendAsync(new DeleteClientCommand(clientCreated.Client.Id));
        objClient.Should().NotBeNull();
    }
}
