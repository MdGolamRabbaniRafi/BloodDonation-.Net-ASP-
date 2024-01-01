using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PaymentInfoDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Card number is required.")]
        [CreditCard(ErrorMessage = "Invalid credit card number.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Cardholder name is required.")]
        public string CardHolderName { get; set; }

        [Required(ErrorMessage = "Expiry month is required.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])$", ErrorMessage = "Invalid expiry month.")]
        public string ExpiryMonth { get; set; }

        [Required(ErrorMessage = "Expiry year is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid expiry year.")]
        public string ExpiryYear { get; set; }

        [Required(ErrorMessage = "CVV is required.")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Invalid CVV.")]
        public string CVV { get; set; }

        // Add more properties as needed (e.g., billing address, etc.)
       
    }
}
