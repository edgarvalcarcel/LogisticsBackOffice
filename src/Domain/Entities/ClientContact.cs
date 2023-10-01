using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsBackOffice.Domain.Entities
{
    public class ClientContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
        public int ContactId { get; set; }
        public virtual Contact? Contact { get; set; }
    }
}
