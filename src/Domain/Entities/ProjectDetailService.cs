using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class ProjectDetailService
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectDetailId { get; set; }
        public virtual ProjectDetail? ProjectDetail { get; set; }
        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
        public int OperatorId { get; set; }
        public virtual Operator? Operator { get; set; }
        public decimal HoursAmount { get; set; } = 0;
    }
}