using BLL.DTO;
using Stripe;
using System;

namespace BLL.Services
{
    public class PaymentGateway
    {
        static PaymentGateway()
        {
            // Configure your Stripe API key
            StripeConfiguration.ApiKey = "your_stripe_api_key";
        }

        public static bool ProcessPayment(PaymentInfoDTO paymentInfo, decimal amount)
        {
            try
            {
                // This is a simplified example assuming you use Stripe
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100), // Convert amount to cents
                    Currency = "usd",
                    PaymentMethod = paymentInfo.CardNumber, // Use the card number as a placeholder
                    Confirm = true,
                };

                var service = new PaymentIntentService();
                var paymentIntent = service.Create(options);

                // Check the payment status
                if (paymentIntent.Status == "succeeded")
                {
                    // Payment is successful
                    return true;
                }
                else
                {
                    // Payment failed
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"Payment processing error: {ex.Message}");
                return false;
            }
        }
    }
}
