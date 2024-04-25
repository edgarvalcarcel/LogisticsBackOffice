using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Responses;
using LogisticsBackOffice.Application.Workers.Commands.Modify;

namespace Application.FunctionalTests.Workers;
public class ModifyWorkerTests : BaseTestFixture
{
    [Test]
    public async Task ShouldModifyClient()
    {
        Faker fake = new();
        var address1 = fake.Address.StreetAddress();
        var address2 = fake.Address.BuildingNumber();
        var city = fake.Address.City();
        var postalcode = fake.Address.ZipCode();
        var locationName = fake.Address.County() + "Store";
        var phoneNumber = fake.Phone.PhoneNumber();

        var modifyCommand = new ModifyWorkerCommand
        {
            Id = 1014,
            Title = "Mr.",
            FirstName = fake.Name.FirstName(),
            LastName = fake.Name.LastName(),
            Role = "Ph.",
            Email = fake.Person.Email.ToLower(),
            Cellphone = fake.Phone.PhoneNumber(),
            AdditionalInfo = " Information for creating worker testing ",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
        };
        modifyCommand.GeographicalInfo.StateId = 11;
        modifyCommand.GeographicalInfo.Id = 74;
        modifyCommand.FullName = string.Concat(modifyCommand.FirstName, " ", modifyCommand.LastName);

        var clientModified = await Testing.SendAsync(modifyCommand);

        clientModified.Should().NotBeNull();
        clientModified.Worker!.FirstName.Should().Be(modifyCommand.FirstName);
        clientModified.Worker!.LastName.Should().Be(modifyCommand.LastName);
        clientModified.Worker!.Email.Should().Be(modifyCommand.Email);
        clientModified.Worker!.Cellphone.Should().Be(modifyCommand.Cellphone);
    }
}
