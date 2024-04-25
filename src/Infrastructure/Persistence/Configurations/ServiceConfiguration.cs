using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Name).HasMaxLength(50).HasPrecision(50);
        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(p => p.Rate).HasColumnType("decimal(18,2)").HasPrecision(18, 2).IsRequired();
    }
}