using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? IsReceivingService { get; set; }
        public bool? IsProcessingService { get; set; }
        public bool? IsWarehouseService { get; set; }
        public bool? IsCleaningService { get; set; }
    }
}
