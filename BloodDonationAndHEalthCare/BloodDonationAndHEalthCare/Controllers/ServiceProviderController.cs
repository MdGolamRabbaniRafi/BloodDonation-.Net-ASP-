using BLL.DTO;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class ServiceProviderController : ApiController
    {
        [HttpGet]
        [Route("api/ServiceProvider/PendingRequests")]
        public HttpResponseMessage GetPendingDonationRequests()
        {
            try
            {
                var pendingDonationRequests = DonationService.GetPendingDonationRequests();

                if (pendingDonationRequests.Count == 0)
                {
                    // No pending requests, return a message
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No pending donation requests." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, pendingDonationRequests);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/ServiceProvider/ApproveDonation/{donationId}")]
        public HttpResponseMessage ApproveDonation(int donationId)
        {
            try
            {
                bool isApproved = DonationService.ApproveDonationRequest(donationId);

                if (isApproved)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Donation request approved successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Donation request not found or already approved." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }





        [HttpPost]
        [Route("api/ServiceProvider/ApproveAndProcessDonation/{donationId}")]
        public HttpResponseMessage ApproveAndProcessDonation(int donationId, PaymentInfoDTO paymentInfo)
        {
            try
            {
                bool isApproved = DonationService.ApproveAndProcessDonation(donationId, paymentInfo);

                if (isApproved)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Donation request approved and payment processed successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Donation request not found, already approved, or payment processing failed." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
