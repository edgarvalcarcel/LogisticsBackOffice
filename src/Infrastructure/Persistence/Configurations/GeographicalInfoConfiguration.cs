using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class GeographicalInfoConfiguration : IEntityTypeConfiguration<GeographicalInfo>
{
    public void Configure(EntityTypeBuilder<GeographicalInfo> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Property(g => g.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(g => g.Id).IsUnique();
        builder.Property(g => g.AddressLine1).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(g => g.AddressLine2).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(g => g.City).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(g => g.PostalCode).HasMaxLength(10).HasPrecision(10).IsRequired();
        builder.Property(g => g.Latitude).HasMaxLength(12).HasPrecision(20);
        builder.Property(g => g.Longitude).HasMaxLength(12).HasPrecision(20);
        builder.Property(g => g.LocationName).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(g => g.PhoneNumber).HasMaxLength(30).HasPrecision(30).IsRequired();

        builder.Property(g => g.CreatedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(g => g.LastModifiedBy).HasMaxLength(100).HasPrecision(100);
    }
}