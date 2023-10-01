using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class State
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? StateCode { get; set; }
        public int CountryRegionId { get; set; }
        public virtual CountryRegion? CountryRegion { get; set; }
        public int TerritoryId { get; set; }
    }
}
