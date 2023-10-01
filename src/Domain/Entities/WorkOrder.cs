using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class WorkOrder
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectDetailId { get; set; }
        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
        public int OperatorId { get; set; }
        public virtual Operator? Operator { get; set; }
        public decimal HoursAmount { get; set; }
        public DateTime? ScheduledStartDate { get; set; }
        public DateTime? ScheduledEndDate { get; set; }
        public DateTime? ModifiedEndDate { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}
