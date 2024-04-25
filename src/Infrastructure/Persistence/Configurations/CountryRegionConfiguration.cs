using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class CountryRegionConfiguration : IEntityTypeConfiguration<CountryRegion>
{
    public void Configure(EntityTypeBuilder<CountryRegion> builder)
    {
        //builder.Property(t => t.Id).UseIdentityColumn().IsRequired(); Id is Imported in a json
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Name).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.CountryRegionCode).HasMaxLength(2).HasPrecision(2).IsRequired();
        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
    }
}
