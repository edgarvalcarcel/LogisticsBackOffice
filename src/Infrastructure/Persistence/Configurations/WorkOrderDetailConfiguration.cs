using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class WorkOrderDetailConfiguration : IEntityTypeConfiguration<WorkOrderDetail>
{
    public void Configure(EntityTypeBuilder<WorkOrderDetail> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Property(p => p.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(pr => pr.Id).IsUnique();
        builder.Property(p => p.WorkOrderId).IsRequired();
        builder.Property(p => p.WorkerId).IsRequired();
        builder.Property(p => p.HoursAmount).HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.ScheduledStartDate);
        builder.Property(p => p.ScheduledEndDate);
        builder.Property(p => p.ActualStartDate);
        builder.Property(p => p.ActualEndDate);
        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100);
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100);
        builder.Property(p => p.PriorityId).IsRequired();
        // relationship
        builder.HasIndex(w => new { w.WorkOrderId, w.WorkerId }).IsUnique();
    }
}
