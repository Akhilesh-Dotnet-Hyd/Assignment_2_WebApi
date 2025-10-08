using System.ComponentModel.DataAnnotations;

namespace Assignment_2_WebApi.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is Mandatory")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Mandatory.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 30 characters.")]
        public required string Name { get; set; }

       
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        public string Department { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Mobile number must be a 10-digit number.")]
        public long MobileNo { get; set; }


    }
}
