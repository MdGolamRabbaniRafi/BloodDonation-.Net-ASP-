using BLL.DTO;
using BLL.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{
    [EnableCors("*", "*", "*")]
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

        [HttpGet]
        [Route("api/ServiceProvider/ApprovedDonations")]
        public HttpResponseMessage GetApprovedDonations()
        {
            try
            {
                var approvedDonations = DonationService.GetApprovedDonations();

                if (approvedDonations.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No approved donations available." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, approvedDonations);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/ServiceProvider/DeleteDonation/{donationId}")]
        public HttpResponseMessage DeleteDonationRequest(int donationId)
        {
            try
            {
                bool isDeleted = DonationService.DeleteDonationRequest(donationId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Donation deleted successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Donation not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
<<<<<<< HEAD
=======
        [HttpGet]
        [Route("api/ServiceProvider/GetAllBloodDonationCampaigns")]
        public HttpResponseMessage GetAllBloodDonationCampaigns()
        {
            try
            {
                var bloodDonationCampaigns = BloodDonationCampaignService.GetAllBloodDonationCampaigns();

                if (bloodDonationCampaigns.Count == 0)
                {
               
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No blood donation campaigns available." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, bloodDonationCampaigns);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc




<<<<<<< HEAD



=======
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
        [HttpGet]
        [Route("api/ServiceProvider/GetUsersJoinedCampaign/{campaignId}")]
        public HttpResponseMessage GetUsersJoinedCampaign(int campaignId)
        {
            try
            {
                var joinedUsers = BloodDonationCampaignService.GetUsersJoinedCampaign(campaignId);

                if (joinedUsers != null && joinedUsers.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, joinedUsers);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "No users joined the campaign or campaign not found." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc

    }
}

