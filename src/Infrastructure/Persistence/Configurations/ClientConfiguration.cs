using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Title).HasMaxLength(3).HasPrecision(3);
        builder.Property(c => c.FirstName).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.Suffix).HasMaxLength(4).HasPrecision(4);
        builder.Property(c => c.Email).HasMaxLength(150).HasPrecision(150).IsRequired();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.Cellphone).HasMaxLength(50).HasPrecision(150).IsRequired();
        builder.Property(c => c.AdditionalInfo).HasMaxLength(150).HasPrecision(150).IsRequired();
        builder.Property(c => c.GeographicalInfoId).IsRequired();
        builder.Property(c => c.Done).HasDefaultValue(false).IsRequired();
        //relationships
        //builder.HasOne(c => c.GeographicalInfo).WithOne(g => g.Client).HasForeignKey<GeographicalInfo>("ClientId").OnDelete(DeleteBehavior.Cascade);
    }
}