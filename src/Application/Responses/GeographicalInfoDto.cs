using System.Diagnostics.CodeAnalysis;

namespace LogisticsBackOffice.Application.Responses;
public class GeographicalInfoDto
{
    public GeographicalInfoDto()
    {
        AddressLine1 = string.Empty;
        AddressLine2 = string.Empty;
        City = string.Empty;
        PostalCode = string.Empty;
        LocationName = string.Empty;
        PhoneNumber = string.Empty;
    }

    public int Id { get; set; }
    public required string AddressLine1 { get; set; }
    public required string AddressLine2 { get; set; }
    public required string City { get; set; }
    public int StateId { get; set; }
    public virtual StateDto? State { get; init; }
    public required string PostalCode { get; set; }
    public string? Latitude { get; init; }
    public string? Longitude { get; init; }
    public required string LocationName { get; set; }
    public required string PhoneNumber { get; set; }
    public virtual ClientDto? Client { get; init; }
    public int? ClientId { get; init; }
    [SetsRequiredMembers]
    public GeographicalInfoDto(string addressLine1,
       string addressLine2,
      string city, string postalCode, string locationName, string phoneNumber)
    {
        (AddressLine1, AddressLine2, City, PostalCode, LocationName, PhoneNumber) = (addressLine1, addressLine2, city, postalCode, locationName, phoneNumber);
    }
}

