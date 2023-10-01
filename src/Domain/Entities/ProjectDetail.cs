using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class ProjectDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
        public decimal Duration { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public virtual ICollection<ProjectDetailService>? ProjectDetailServices { get; set; }
    }
}
