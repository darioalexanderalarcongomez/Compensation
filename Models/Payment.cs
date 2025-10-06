using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compensation.Models
{
    public class Payment
    {
        [Key]
        public int  Payment_Id{ get; set; }

        public required int TypePayment_Id { get; set; }
        public required int Event_Id { get; set; }
        [Display(Name = "Payment Order")]
        public string? PaymentOrder { get; set; }
        [Display(Name = "Type of Payment")]

        [ForeignKey("TypePayment_Id")]
        public TypePayment TypePayment { get; set; }

        [ForeignKey("Event_Id")]
        public Event Event { get; set; }

    }
}
