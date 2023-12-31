using BLL.DTO;
using Stripe;
using System;

namespace BLL.Services
{
    public class PaymentGateway
    {
        static PaymentGateway()
        {
          
            StripeConfiguration.ApiKey = "sk_test_51OSim2BmCAbE1nO4GDDSfnbjEu7mtRtfHMTp5Hafs9pRR93OxFSJIqViz4Lr05AxZJs5t6ec7OrwJ0fhIdLdu1LG00Pb5JWy5N";
        }

        public static bool ProcessPayment(PaymentInfoDTO paymentInfo, decimal amount)
        {
            try
            {
              
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100), 
                    Currency = "usd",
                    PaymentMethod = paymentInfo.CardNumber, 
                    Confirm = true,
                };

                var service = new PaymentIntentService();
                var paymentIntent = service.Create(options);

             
                if (paymentIntent.Status == "succeeded")
                {
                    return true;
                }
                else
                {
                    
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Payment processing error: {ex.Message}");
                return false;
            }
        }
    }
}
