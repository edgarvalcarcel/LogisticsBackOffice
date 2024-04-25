using LogisticsBackOffice.Domain.Entities;

namespace LogisticsBackOffice.Application.Common.Interfaces;
public interface IGeographicalInfoRepository
{
    IQueryable<GeographicalInfo> GetAll();
    GeographicalInfo GetGeoInformationById(int id);
    Task<List<GeographicalInfo>> GetAllAsync();
    Task<GeographicalInfo> AddGeoInformationAsync(GeographicalInfo geoInformation);
    GeographicalInfo UpdateGeoInformationAsync(GeographicalInfo geoInformation);
    Task DeleteGeoInformationAsync(GeographicalInfo geoInformation);
    GeographicalInfo? GetGeoInformationByData(GeographicalInfo dataGeo);
}