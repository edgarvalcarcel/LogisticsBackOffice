using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Entity).HasMaxLength(20).HasPrecision(20).IsRequired();
        builder.Property(c => c.Name).HasMaxLength(20).HasPrecision(20).IsRequired();
        builder.Property(c => c.Order).IsRequired();
    }
}