using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Property(p => p.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(pr => pr.Id).IsUnique();
        builder.Property(p => p.ClientId).IsRequired();
        //builder.Property(p => p.ProcessingDate).IsRequired();
        builder.Property(p => p.ContactId).IsRequired();
        builder.Property(p => p.Amount).HasPrecision(18, 2);
        builder.Property(p => p.EmailSent).HasMaxLength(80).HasPrecision(80);
        builder.Property(p => p.GeographicalInfoId).IsRequired();
        builder.Property(p => p.DriverName).HasMaxLength(80).HasPrecision(80);
        builder.Property(p => p.ShippingNumber).HasMaxLength(80).HasPrecision(80);
        builder.Property(p => p.ShipperOrigin).HasMaxLength(80).HasPrecision(80);

        builder.HasMany(pd => pd.ProjectDetail).WithOne(pds => pds.Project).HasForeignKey(pds => pds.ProjectId);
    }
}