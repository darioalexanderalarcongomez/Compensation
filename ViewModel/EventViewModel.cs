using System.ComponentModel.DataAnnotations;

namespace Compensation.ViewModel
{
    public class EventViewModel
    {
        public int Event_Id { get; set; }

        [Required]
        [Display(Name = "Event")]
        public string Description_Event { get; set; }

        [Required]
        [Display(Name = "Clock In")]
        public DateTime ClockIn_Event { get; set; }

        [Required]
        [Display(Name = "Clock Out")]
        public DateTime ClockOut_Event { get; set; }

        [Display(Name = "Profit")]
        public decimal? Profit { get; set; }

        [Display(Name = "Minutes Worked")]
        public int? MinutesWorked { get; set; }

        [Required]
        [Display(Name = "Fares")]
        public int Fare_Id { get; set; }

        [Required]
        [Display(Name = "Employees")]
        public int Employee_Id { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public int Venue_Id { get; set; }
    }

}
