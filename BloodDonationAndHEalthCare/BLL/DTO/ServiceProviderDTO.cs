using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ServiceProviderDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is Required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        // You can add a regular expression for password complexity if needed
        public string Password { get; set; }

        [Required(ErrorMessage = "Blood group is Required")]
        [RegularExpression(@"^(A|B|AB|O)[+-]?$", ErrorMessage = "Invalid Blood Group")]
        public string BloodGroup { get; set; }

    }
}
