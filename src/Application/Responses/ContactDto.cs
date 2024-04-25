namespace LogisticsBackOffice.Application.Responses;
public class ContactDto
{
    public ContactDto()
    {
        Title = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Cellphone = string.Empty;
        AdditionalInfo = string.Empty;
        Role = string.Empty;
    }
    public int Id { get; set; }
    public string? Title { get; init; }
    public string? FullName { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Suffix { get; init; }
    public string? Email { get; init; }
    public string? Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
    public string? Role { get; init; }
    public ContactDto(string title, string firstName, string lastName, string email,
string cellphone, string additionalInfo, string role)
    {
        (Title, FirstName, LastName, Email, Cellphone, AdditionalInfo, Role) = (title, firstName, lastName, email, cellphone, additionalInfo, role);
    }
}