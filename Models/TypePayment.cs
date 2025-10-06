using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compensation.Models
{
    public class TypePayment
    {
        [Key]
        public int TypePayment_Id { get; set; }
        [Display(Name = "Type of Payment")]
        public string? DescriptionType { get; set; }
        public ICollection<Payment> Payments { get;set; } = new List<Payment>();
    }
}
