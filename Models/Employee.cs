using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compensation.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        [Display(Name = "First Name")]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Text)]
        public required string FirstName { get; set; }
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        [Display(Name = "Last Name")]
        [Column(TypeName = "varchar(100)")]
        [DataType(DataType.Text)]
        public required string LastName { get; set; }
        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName; 
            }
        }
        [InverseProperty("Employee")]
        public ICollection<Event> Events { get; set; } = new List<Event>();
        //[InverseProperty("Address")]
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
