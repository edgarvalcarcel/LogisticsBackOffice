using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.Title).HasPrecision(4);
        builder.Property(c => c.FirstName).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.Suffix).HasMaxLength(4).HasPrecision(4);
        builder.Property(c => c.Email).HasMaxLength(150).HasPrecision(150).IsRequired();
        builder.Property(c => c.Cellphone).HasMaxLength(50).HasPrecision(50).IsRequired();
        builder.Property(c => c.AdditionalInfo).HasMaxLength(150).HasPrecision(150);
        builder.Property(c => c.Role).HasMaxLength(50).HasPrecision(50);
        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100);
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100);
    }
}