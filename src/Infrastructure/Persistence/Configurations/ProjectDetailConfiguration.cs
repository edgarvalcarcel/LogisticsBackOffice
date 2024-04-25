using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class ProjectDetailConfiguration : IEntityTypeConfiguration<ProjectDetail>
{
    public void Configure(EntityTypeBuilder<ProjectDetail> builder)
    {
        builder.Property(pd => pd.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(pd => pd.Id).IsUnique();
        builder.Property(t => t.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(c => c.Id).IsUnique();

        builder.Property(c => c.ProjectId).IsRequired();
        builder.Property(c => c.ServiceId).IsRequired();
        builder.HasIndex(pd => new { pd.ProjectId, pd.ServiceId }).IsUnique();
        builder.Property(p => p.Duration).HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.Rate).HasColumnType("decimal(18,2)").HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.Amount).HasPrecision(18, 2).IsRequired();

        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100);
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100);
        //builder.HasMany(pd => pd.WorkOrders).WithOne(w => w.ProjectDetail).HasForeignKey(w => w.ProjectDetailId).OnDelete(DeleteBehavior.NoAction);
    }
}