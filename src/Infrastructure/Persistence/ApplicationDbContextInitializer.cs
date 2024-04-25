using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LogisticsBackOffice.Infrastructure.Persistence;

public class ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
{
    public async Task InitialiseAsync()
    {
        try
        {
            if (context.Database.IsSqlServer())
            {
                await context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        await using var stream = File.OpenRead("../LogisticsBackOfficeDataImporter.json");
        using var reader = new JsonTextReader(new StreamReader(stream));

        var readerFile = await JArray.LoadAsync(reader);

        var countries = new List<CountryRegion>();
        if (!context.CountryRegion.Any())
        {
            foreach (var countryData in readerFile[0]["countryregions"]!)
            {
                var countryRecord = new CountryRegion
                {
                    Id = (int)countryData["Id"]!,
                    Name = countryData["Name"]!.ToString(),
                    CountryRegionCode = countryData["CountryRegionCode"]!.ToString(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "Database Initialization process",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "Database Initialization process"
                };
                context.CountryRegion.Add(countryRecord);
            }
        }

        var states = new List<State>();
        if (!context.State.Any())
        {
            foreach (var stateData in readerFile[0]["states"]!)
            {
                var stateRecord = new State
                {
                    Id = (int)stateData["Id"]!,
                    Name = stateData["Name"]!.ToString(),
                    StateCode = stateData["StateCode"]!.ToString().Trim(),
                    CountryRegionId = (int)stateData["CountryRegionId"]!,
                    TerritoryId = (int)stateData["TerritoryID"]!,
                    Created = DateTime.UtcNow,
                    CreatedBy = "Database Initialization process",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "Database Initialization process"
                };
                context.State.Add(stateRecord);
            }
        }

        var geographicalInfo = new List<GeographicalInfo>();
        if (!context.GeographicalInfo.Any())
        {
            foreach (var geographicalInfoData in readerFile[0]["geographicalInfos"]!)
            {
                var geographicalInfoRecord = new GeographicalInfo(" ", " ", " ", " ", " ", " ")
                {
                    AddressLine1 = geographicalInfoData["AddressLine1"]!.ToString(),
                    AddressLine2 = geographicalInfoData["AddressLine2"]!.ToString(),
                    City = geographicalInfoData["City"]!.ToString(),
                    StateId = (int)geographicalInfoData["StateId"]!,
                    PostalCode = geographicalInfoData["PostalCode"]!.ToString(),
                    Latitude = geographicalInfoData["Latitude"]!.ToString().Trim(),
                    Longitude = geographicalInfoData["Longitude"]!.ToString().Trim(),
                    LocationName = geographicalInfoData["LocationName"]!.ToString(),
                    PhoneNumber = geographicalInfoData["PhoneNumber"]!.ToString(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "Database Initialization process",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "Database Initialization process"
                };
                context.GeographicalInfo.Add(geographicalInfoRecord);
            }
        }

        var status = new List<Status>();
        if (!context.Status.Any())
        {
            foreach (var statusData in readerFile[0]["status"]!)
            {
                var statusRecord = new Status
                {
                    //Id = (int)statusData["Id"]!,
                    Name = statusData["Name"]!.ToString().Trim(),
                    Entity = statusData["Entity"]!.ToString().Trim(),
                    Order = (int)statusData["Order"]!,
                    IsEnabled = (bool)statusData["IsEnabled"]!,
                    Description = statusData["Description"]!.ToString().Trim()
                };
                context.Status.Add(statusRecord);
            }
        }
        var services = new List<Service>();
        if (!context.Service.Any())
        {
            foreach (var serviceData in readerFile[0]["services"]!)
            {
                var serviceRecord = new Service
                {
                    //Id = (int)serviceData["Id"]!,
                    Name = serviceData["Name"]!.ToString().Trim(),
                    Rate = (decimal)serviceData["Rate"]!,

                    Created = DateTime.UtcNow,
                    CreatedBy = "Database Initialization process",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "Database Initialization process"
                };
                context.Service.Add(serviceRecord);
            }
        }

        var couriers = new List<CourierCompany>();
        if (!context.CourierCompany.Any())
        {
            foreach (var serviceData in readerFile[0]["couriers"]!)
            {
                var courierRecord = new CourierCompany
                {
                    //Id = (int)serviceData["Id"]!,
                    Name = serviceData["Name"]!.ToString().Trim(),
                    Created = DateTime.UtcNow,
                    CreatedBy = "Database Initialization process",
                    LastModified = DateTime.UtcNow,
                    LastModifiedBy = "Database Initialization process"
                };
                context.CourierCompany.Add(courierRecord);
            }
        }
        await context.SaveChangesAsync();
    }
}


