using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compensation.Models
{
    public class Fare
    {
        [Key]
        public int Fare_Id { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Fare x Hour")]
        public decimal Fare_Value { get; set; }
        
        [InverseProperty("Fare")]
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
