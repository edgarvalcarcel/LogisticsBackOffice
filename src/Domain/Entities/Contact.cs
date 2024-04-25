namespace LogisticsBackOffice.Domain.Entities;
public class Contact : BaseIdEntity
{
    public string? Title { get; set; }
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Suffix { get; set; }
    public string? Email { get; set; }
    public string? Cellphone { get; set; }
    public string? AdditionalInfo { get; set; }
    public string? Role { get; set; }
    public bool? IsStaff { get; set; }
}
