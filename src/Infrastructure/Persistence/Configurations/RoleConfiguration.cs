using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        //builder.Property(t => t.Id).UseIdentityColumn().IsRequired(); Id is Imported in a json
        builder.HasIndex(c => c.Id).IsUnique();
        builder.Property(c => c.Name).HasMaxLength(50).HasPrecision(50);
    }
}