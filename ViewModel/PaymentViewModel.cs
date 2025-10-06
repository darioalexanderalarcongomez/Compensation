using System.ComponentModel.DataAnnotations;

namespace Compensation.ViewModel
{
    public class PaymentViewModel
    {
        public int Payment_Id { get; set; }
        [Display(Name = "Type Payment")]
        public int TypePayment_Id { get; set; }
        [Display(Name = "Event")]
        public int Event_Id { get; set; }
        [Display(Name = "Payment")]
        public string? PaymentOrder { get; set; }

    }
}
