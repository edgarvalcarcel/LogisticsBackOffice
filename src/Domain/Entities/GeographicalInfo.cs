using System.Diagnostics.CodeAnalysis;

namespace LogisticsBackOffice.Domain.Entities;
public class GeographicalInfo : BaseIdEntity
{
    public GeographicalInfo()
    {
        AddressLine1 = string.Empty;
        AddressLine2 = string.Empty;
        City = string.Empty;
        PostalCode = string.Empty;
        LocationName = string.Empty;
        PhoneNumber = string.Empty;
    }
    public required string AddressLine1 { get; set; }
    public required string AddressLine2 { get; set; }
    public required string City { get; set; }
    public int StateId { get; set; }
    public virtual State? State { get; set; }
    public required string PostalCode { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public required string LocationName { get; set; }
    public required string PhoneNumber { get; set; }

    [SetsRequiredMembers]
    public GeographicalInfo(string addressLine1,
        string addressLine2,
       string city, string postalCode, string locationName, string phoneNumber)
    {
        (AddressLine1, AddressLine2, City, PostalCode, LocationName, PhoneNumber) = (addressLine1, addressLine2, city, postalCode, locationName, phoneNumber);
    }
}

