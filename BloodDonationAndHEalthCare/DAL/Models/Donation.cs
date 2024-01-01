using System;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc

namespace DAL.Models
{
    public class Donation
    {
        public int Id { get; set; }
<<<<<<< HEAD
    
=======
        public int UserId { get; set; }
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public bool IsPaid { get; set; }
<<<<<<< HEAD
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

=======
    }
}
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
