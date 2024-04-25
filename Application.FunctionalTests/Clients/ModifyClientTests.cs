using Bogus;
using FluentAssertions;
using LogisticsBackOffice.Application.Clients.Commands.Modify;
using LogisticsBackOffice.Application.FunctionalTests;
using LogisticsBackOffice.Application.FunctionalTests.Common;
using LogisticsBackOffice.Application.Responses;

namespace Application.FunctionalTests.Clients;
public class ModifyClientTests : BaseTestFixture
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

        var modifyCommand = new ModifyClientCommand
        {
            Id = 43,
            Title = "Dr",
            FirstName = fake.Name.FirstName(),
            LastName = fake.Name.LastName(),
            Suffix = "D ",
            Email = fake.Person.Email.ToLower(),
            Cellphone = fake.Phone.PhoneNumber(),
            AdditionalInfo = " Information",
            GeographicalInfo = new GeographicalInfoDto(address1, address2, city, postalcode, locationName, phoneNumber)
            {
                StateId = 19,
                Id = 99
            }
        };
        modifyCommand.GeographicalInfo.StateId = 11;

        modifyCommand.FullName = string.Concat(modifyCommand.FirstName, " ", modifyCommand.LastName);

        var clientModified = await Testing.SendAsync(modifyCommand);

        clientModified.Should().NotBeNull();
        clientModified.Client!.FirstName.Should().Be(modifyCommand.FirstName);
        clientModified.Client!.LastName.Should().Be(modifyCommand.LastName);
        clientModified.Client!.Email.Should().Be(modifyCommand.Email);
        clientModified.Client!.Cellphone.Should().Be(modifyCommand.Cellphone);
    }
}
