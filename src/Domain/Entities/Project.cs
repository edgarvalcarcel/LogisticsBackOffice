using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ReceivingDate { get; set; }
        public DateTime? ProcessingDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TotalReceivedPackages { get; set; }
        public int? TotaOperators { get; set; }
        public int? Sidemark { get; set; }
        public int? ContactId { get; set; }
        public virtual Contact? Contact { get; set; }
        public bool? DeclaredValueInsurace { get; set; }
        public decimal? Amount { get; set; }
        public string? InspectionNotes { get; set; }
        public bool? ReplaytoEmail { get; set; }
        public string? EmailSent { get; set; }
        public int? GeographicalInfoId { get; set; }
        public virtual GeographicalInfo? GeographicalInfo { get; set; }
        public int? OperatorIdReceiving { get; set; }
        public virtual Operator? OperatorReceiving { get; set; }
        public string? DriverName { get; set; }
        public string? ShippingNumber { get; set; }
        public string? ShippingOrigin { get; set; }
        public string? ProjectQRGenerated { get; set; }
        public virtual ICollection<ProjectDetail>? ProjectDetails { get; set; }
    }
}
