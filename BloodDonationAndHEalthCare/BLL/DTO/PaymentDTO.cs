using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }

        [Required]
        public int DonationId { get; set; }

        [Required]
        public string TransactionId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        public bool IsSuccessful { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
