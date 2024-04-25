using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class CourierCompanyConfiguration : IEntityTypeConfiguration<CourierCompany>
{
    public void Configure(EntityTypeBuilder<CourierCompany> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Name).HasMaxLength(100).HasPrecision(100).IsRequired();
    }
}
