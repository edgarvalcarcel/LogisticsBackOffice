using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Responses;
public record ClientDto
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? FullName { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Suffix { get; init; }
    public string? Email { get; init; }
    public string? Cellphone { get; init; }
    public string? AdditionalInfo { get; init; }
    public int GeographicalInfoId { get; init; }
    public virtual GeographicalInfoDto? GeographicalInfo { get; init; }
    public IList<ClientContact> ClientContact { get; set; } = [];
};
