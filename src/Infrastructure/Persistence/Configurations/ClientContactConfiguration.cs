using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class ClientContactConfiguration : IEntityTypeConfiguration<ClientContact>
{
    public void Configure(EntityTypeBuilder<ClientContact> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
    }
}