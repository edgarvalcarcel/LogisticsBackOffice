using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();

        builder.Property(c => c.Title).HasMaxLength(4).HasPrecision(4);
        builder.Property(c => c.FirstName).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(c => c.Cellphone).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.Role).HasMaxLength(50).HasPrecision(50).IsRequired();

        builder.Property(c => c.AdditionalInfo).HasMaxLength(100).HasPrecision(100);
        builder.Property(c => c.GeographicalInfoId).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.UserId).HasMaxLength(50).HasPrecision(50);
    }
}
