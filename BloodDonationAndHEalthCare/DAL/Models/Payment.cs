using System;

namespace DAL.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int DonationId { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public bool IsSuccessful { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
