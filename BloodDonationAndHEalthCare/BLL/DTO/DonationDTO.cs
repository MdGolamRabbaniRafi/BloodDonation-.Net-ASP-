using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class DonationDTO
    {
        public int Id { get; set; }

        [Required]
<<<<<<< HEAD
       

     
=======
        public int UserId { get; set; }

        [Required]
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public bool IsPaid { get; set; }
<<<<<<< HEAD
        public int UserId { get; set; }

    }
}
=======
    }
}
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
