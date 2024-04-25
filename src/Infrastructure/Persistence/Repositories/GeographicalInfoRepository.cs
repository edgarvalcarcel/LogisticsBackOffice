using LogisticsBackOffice.Application.Common.Exceptions;
using LogisticsBackOffice.Application.Common.Interfaces;
using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ArgumentNullException = LogisticsBackOffice.Application.Common.Exceptions.ArgumentNullException;

namespace LogisticsBackOffice.Infrastructure.Persistence.Repositories;
public class GeographicalInfoRepository(IRepositoryAsync<GeographicalInfo> geoInformationRepository, ApplicationDbContext dbContext) : IGeographicalInfoRepository
{
    private readonly IRepositoryAsync<GeographicalInfo> _geoInformationRepository = geoInformationRepository;
    private readonly ApplicationDbContext _dbContext = dbContext;

    public IQueryable<GeographicalInfo> GetAll() => _geoInformationRepository.Entities;
    public async Task<GeographicalInfo> AddGeoInformationAsync(GeographicalInfo geoInformation)
    {
        return await _geoInformationRepository.AddAsync(geoInformation);
    }

    public GeographicalInfo GetGeoInformationById(int id)
    {
        var resultGeographicalInfo = new GeographicalInfo("", "", "", "", "", "");
        resultGeographicalInfo = _dbContext.GeographicalInfo.Where(g => g.Id == id).Include(g => g.State).FirstOrDefault() ?? throw new NotFoundException(nameof(GeographicalInfo), id);
        return resultGeographicalInfo;
    }

    public GeographicalInfo UpdateGeoInformationAsync(GeographicalInfo geoInformation)
    {
        return _geoInformationRepository.Update(geoInformation);
    }

    public Task DeleteGeoInformationAsync(GeographicalInfo geoInformation)
    {
        return _geoInformationRepository.DeleteAsync(geoInformation);
    }

    public async Task<List<GeographicalInfo>> GetAllAsync()
    {
        return await _geoInformationRepository.GetAllAsync();
    }

    public GeographicalInfo? GetGeoInformationByData(GeographicalInfo dataGeo)
    {
        ArgumentNullException.ThrowIfNull(dataGeo);
        ArgumentNullException.ThrowIfNull(dataGeo.AddressLine1);
        ArgumentNullException.ThrowIfNull(dataGeo.AddressLine2);
        ArgumentNullException.ThrowIfNull(dataGeo.City);
        ArgumentNullException.ThrowIfNull(dataGeo.PostalCode);

        var geoDataResult = _dbContext.GeographicalInfo
        .Where(
          g => g.AddressLine1 == dataGeo.AddressLine1
            && g.AddressLine2 == dataGeo.AddressLine2
          && g.City == dataGeo.City
          && g.PostalCode == dataGeo.PostalCode)
        .Include(c => c.State).FirstOrDefault();
        return geoDataResult;
    }
}
