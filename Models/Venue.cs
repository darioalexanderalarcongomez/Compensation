using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compensation.Models
{
    public class Venue
    {
        [Key]
        public int Venue_Id { get; set; }
        [Display(Name = "Venue")]
        [Column(TypeName = "varchar(250)")]
        [DataType(DataType.Text)]
        public required string Description { get; set; }

        [InverseProperty("Venue")]
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
