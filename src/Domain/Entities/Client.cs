using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class Client
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Suffix { get; set; }
        public string? Email { get; set; }
        public string? Cellphone { get; set; }
        public string? AdditionalInfo { get; set; }
        public int GeographicalnfoId { get; set; }
        public virtual GeographicalInfo? Geographicalnfo { get; set; }
        public virtual Project? Project { get; set; }
    }
}
