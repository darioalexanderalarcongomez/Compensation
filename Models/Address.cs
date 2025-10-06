using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Compensation.Models
{
    public class Address
    {
        [Key]
        public int Address_Id { get; set; }
        [StringLength(10, ErrorMessage = "Postal code cannot be longer than 10 characters.")]
        [Display(Name = "Postal Code")]
        [Column(TypeName = "varchar(10)")]
        [DataType(DataType.Text)]
        public string? PostalCode { get; set; }
        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        [Display(Name = "Address")]
        [Column(TypeName = "varchar(250)")]
        [DataType(DataType.Text)]
        public string? Place { get; set; }
        [StringLength(50, ErrorMessage = "State cannot be longer than 50 characters.")]
        [Display(Name = "State")]
        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        public string? State { get; set; }
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        [Display(Name = "City")]
        [Column(TypeName = "varchar(50)")]
        [DataType(DataType.Text)]
        public string? City { get; set; }
        public required int Employee_Id { get; set; }
        [ForeignKey("Employee_Id")]
        public required Employee Employees { get; set; }
    }
}
