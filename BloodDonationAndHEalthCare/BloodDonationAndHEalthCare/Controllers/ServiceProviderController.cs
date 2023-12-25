using BLL.DTO;
using BLL.DTOs;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class ServiceProviderController : ApiController
    {
        [Logged]
        [HttpPost]
        [Route("api/ServiceProvider/SignUp")]
        public HttpResponseMessage SignUpServiceProvider(ServiceProviderDTO serviceProvider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                // Add any additional logic for signing up a service provider
                var data = ServiceProviderService.SignUpService(serviceProvider);

                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [HttpPost]
        [Route("api/ServiceProvider/Update/{serviceProviderId}")]
        public HttpResponseMessage UpdateServiceProvider(int serviceProviderId, ServiceProviderDTO serviceProvider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                // Implement logic for updating the service provider's profile
                var updatedServiceProvider = ServiceProviderService.UpdateServiceProvider(serviceProviderId, serviceProvider);

                if (updatedServiceProvider != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, updatedServiceProvider);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Service provider not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [HttpDelete]
        [Route("api/ServiceProvider/Delete/{serviceProviderId}")]
        public HttpResponseMessage DeleteServiceProvider(int serviceProviderId)
        {
            try
            {
                var isDeleted = ServiceProviderService.DeleteServiceProvider(serviceProviderId);

                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Service provider deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Service provider not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/ServiceProvider/{serviceProviderId}")]
        public HttpResponseMessage GetServiceProvider(int serviceProviderId)
        {
            try
            {
                var serviceProvider = ServiceProviderService.GetServiceProvider(serviceProviderId);

                if (serviceProvider != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, serviceProvider);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Service provider not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
