using BLL.DTO;
using BLL.DTOs;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{

    [EnableCors("*", "*", "*")]
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/User/add")]
        public HttpResponseMessage AddUser(UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var data = UserService.AddUserService(user);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/User/{userId}")]
        public HttpResponseMessage GetUser(int userId)
        {
            try
            {
                var data = UserService.GetUser(userId);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }



        [HttpPost]
        [Route("api/User/update/{userId}")]
        public HttpResponseMessage UpdateUser(int userId, [FromBody] UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var updatedUser = UserService.UpdateUserService(userId, user);

                if (updatedUser != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, updatedUser);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/User/delete/{userId}")]
        public HttpResponseMessage DeleteUser(int userId)
        {
            try
            {
                var isSuccess = UserService.DeleteUserService(userId);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "User deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "User not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/User/Login")]
        public HttpResponseMessage LoginUser(UserDTO user)
        {
            try
            {

                var data = UserService.Authenticate(user.Email, user.Password);
                return Request.CreateResponse(HttpStatusCode.Created, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/User/Donate")]
        public HttpResponseMessage Donate(DonationDTO donationDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var createdDonation = DonationService.CreateDonationRequest(donationDTO);

                if (createdDonation != null)
                {
                    // Optional: Notify the user about the successful donation request
                    // You can use email, push notifications, etc., for this purpose.
                    var notificationMessage = $"Donation request created successfully with ID: {createdDonation.Id}";
                    // SendNotificationToUser(user.Email, notificationMessage);

                    return Request.CreateResponse(HttpStatusCode.Created, createdDonation);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to create donation request" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }





        [HttpGet]
        [Route("api/User/ApprovedDonations")]
        public HttpResponseMessage GetApprovedDonations()
        {
            try
            {
                var approvedDonations = DonationService.GetApprovedDonations();

                if (approvedDonations.Count == 0)
                {
                    // No approved donations, return a message
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "No approved donations." });
                }

                return Request.CreateResponse(HttpStatusCode.OK, approvedDonations);
            }
            catch (Exception)
            {
                // Log the exception for troubleshooting
                // You may also want to notify the user about the error
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "An error occurred while retrieving approved donations." });
            }
        }




        [HttpPost]
        [Route("api/User/MakePayment/{donationId}")]
        public HttpResponseMessage MakePayment(int donationId, PaymentInfoDTO paymentInfo)
        {
            try
            {
                // Retrieve the approved donation details
                var approvedDonation = DonationService.GetApprovedDonationById(donationId);

                if (approvedDonation == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Donation request not found or not approved." });
                }

                // Check if the donation has not been paid
                if (!approvedDonation.IsPaid)
                {
                    // Optional: Validate payment information here if needed

                    // Process payment using the PaymentGateway
                    bool paymentSuccess = PaymentGateway.ProcessPayment(paymentInfo, approvedDonation.Amount);

                    if (paymentSuccess)
                    {
                        // Mark the donation as paid
                        DonationService.MarkDonationAsPaid(approvedDonation.Id);

                        return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Payment successful." });
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Payment failed. Please check your payment information and try again." });
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "Donation has already been paid." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [HttpPost]
        [Route("api/User/JoinBloodDonationCampaign/{userId}/{campaignId}")]
        public HttpResponseMessage JoinBloodDonationCampaign(int userId, int campaignId)
        {
            try
            {
                bool isJoined = UserService.JoinBloodDonationCampaign(userId, campaignId);

                if (isJoined)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "User joined the blood donation campaign successfully." });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, new { Msg = "User could not join the blood donation campaign." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }



    }
}
