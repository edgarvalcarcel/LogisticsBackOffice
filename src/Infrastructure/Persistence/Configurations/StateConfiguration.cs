using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        //builder.Property(t => t.Id).UseIdentityColumn().IsRequired(); Id is Imported in a json
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Name).HasMaxLength(50).HasPrecision(50);
        builder.Property(c => c.StateCode).HasMaxLength(2).HasPrecision(3).IsRequired();
        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100).IsRequired();
    }
}
