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
        [HttpGet]
        [Route("api/ServiceProvider/GetAllBloodDonationCampaigns")]
        public HttpResponseMessage GetAllBloodDonationCampaigns()
        {
            try
            {
                var bloodDonationCampaigns = BloodDonationCampaignService.GetAllBloodDonationCampaigns();

                if (bloodDonationCampaigns.Count == 0)
                {
                    // No blood donation campaigns, return a message
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No blood donation campaigns available." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, bloodDonationCampaigns);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }




        [HttpPost]
        [Route("api/ServiceProvider/CreateBloodDonationCampaign")]
        public HttpResponseMessage CreateBloodDonationCampaign(BloodDonationCampaignDTO bloodDonationCampaign)
        {
            try
            {
                BloodDonationCampaignService.AddBloodDonationCampaign(bloodDonationCampaign);
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Blood donation campaign created successfully." });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }



        [HttpPost]
        [Route("api/ServiceProvider/DeleteBloodDonationCampaign/{campaignId}")]
        public HttpResponseMessage DeleteBloodDonationCampaign(int campaignId)
        {
            try
            {
                bool isDeleted = BloodDonationCampaignService.DeleteBloodDonationCampaign(campaignId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Blood donation campaign deleted successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Blood donation campaign not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/ServiceProvider/UpdateBloodDonationCampaign/{campaignId}")]
        public HttpResponseMessage UpdateBloodDonationCampaign(int campaignId, [FromBody] BloodDonationCampaignDTO campaign)
        {
            try
            {
                var updatedCampaign = BloodDonationCampaignService.UpdateBloodDonationCampaign(campaignId, campaign);

                if (updatedCampaign != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedCampaign);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Blood donation campaign not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}

