using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.Workers.Commands.Create;
using LogisticsBackOffice.Application.Workers.Commands.Delete;

namespace Application.FunctionalTests.Workers;

public class DeleteWorkerTests
{
    [Test]
    public async Task ShouldDeleteWorker()
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
        command.GeographicalInfo.StateId = 10;
        command.FullName = string.Concat(command.FirstName, " ", command.LastName);
        var clientCreated = await Testing.SendAsync(command);

        var objClient = await Testing.SendAsync(new DeleteWorkerCommand(clientCreated.Worker.Id));
        objClient.Should().NotBeNull();
    }
}