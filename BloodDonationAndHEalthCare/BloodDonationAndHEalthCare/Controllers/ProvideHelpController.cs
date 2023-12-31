using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class ProvideHelpController : ApiController
    {
        [HttpPost]
        [Route("api/ProvideHelp/GiveHelp")]
        public HttpResponseMessage AddProvideHelp(ProvideHelpDTO provideHelp)
        {
            try
            {
                var addedProvideHelp = ProvideHelpService.AddProvideHelp(provideHelp);

                if (addedProvideHelp != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, addedProvideHelp);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = "Failed to add provide help." });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
