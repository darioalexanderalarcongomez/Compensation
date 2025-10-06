using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Compensation.Models
{
    public class Event
    {
        [Key]
        public int Event_Id { get; set; }
        [Display(Name = "Event")]
        [Column(TypeName = "varchar(200)")]
        [DataType(DataType.Text)]
        public required string Description_Event { get; set; }
        [Display(Name = "Clock In")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public required DateTime ClockIn_Event { get; set; }
        [Display(Name = "Clock Out")]
        [Column(TypeName = "DateTime")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm}")]
        public required DateTime ClockOut_Event { get; set; }
        [Display(Name = "Profit")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal? Profit { get; set; }
        [Display(Name = "Minutes Worked")]
        public int? MinutesWorked { get; set; }
        public int? Hours 
        { 
            get
            {
                return MinutesWorked / 60;
            }  
        }
        public int? Minutes 
        {   
            get
            {
                return MinutesWorked % 60;
            }
        }
        public int Week
        { get
            {
                Calendar calendar = CultureInfo.CurrentCulture.Calendar;
                CalendarWeekRule rule = CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule;
                DayOfWeek firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

                int weekNumber = calendar.GetWeekOfYear(ClockIn_Event, rule, firstDayOfWeek);
                return weekNumber;
            } 
        }
        [Display(Name = "Fares")]
        public required int Fare_Id { get; set; }
        [Display(Name = "Employees")]
        public required int Employee_Id { get; set; }
        [Display(Name = "Venue")]
        public required int Venue_Id { get; set; }
        [ForeignKey("Fare_Id")]
        [ScaffoldColumn(false)]
        public Fare Fare { get; set; }
        [ForeignKey("Employee_Id")]
        [ScaffoldColumn(false)]
        public Employee Employee { get; set; }
        [ForeignKey("Venue_Id")]
        [ScaffoldColumn(false)]
        public Venue Venue { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
