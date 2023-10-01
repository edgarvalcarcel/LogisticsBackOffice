using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;

public interface IGeographicalInfoRepository
{
    Task AddGeographicalInfoAsync(GeographicalInfo geographicalInfo, CancellationToken cancellationToken);
    IQueryable<GeographicalInfo> GetAllGeographicalInfo();
    Task<GeographicalInfo?> FindGeographicalInfoByIdAsync(int id, CancellationToken cancellationToken);
    Task UpdateGeographicalInfoAsync(GeographicalInfo geographicalInfo, CancellationToken cancellationToken);
}