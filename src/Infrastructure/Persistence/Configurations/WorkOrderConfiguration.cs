using LogisticsBackOffice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticsBackOffice.Infrastructure.Persistence.Configurations;
public class WorkOrderConfiguration : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.Property(p => p.Id).UseIdentityColumn().IsRequired();
        builder.HasIndex(pr => pr.Id).IsUnique();
        builder.Property(p => p.ProjectDetailId).IsRequired();
        builder.Property(p => p.ServiceId).IsRequired();
        builder.Property(p => p.HoursAmount).HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.ScheduledStartDate);
        builder.Property(p => p.ScheduledEndDate);
        builder.Property(p => p.ActualStartDate);
        builder.Property(p => p.ActualEndDate);

        builder.Property(c => c.CreatedBy).HasMaxLength(100).HasPrecision(100);
        builder.Property(c => c.LastModifiedBy).HasMaxLength(100).HasPrecision(100);
        // relationship
        builder.HasIndex(w => new { w.ProjectId, w.ProjectDetailId, w.ServiceId }).IsUnique();
        builder.HasOne(w => w.ProjectDetail);
        builder.HasMany(pd => pd.WorkOrderDetail).WithOne(pds => pds.WorkOrder).HasForeignKey(pds => pds.WorkOrderId);
    }
}