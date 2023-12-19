using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class AdminUserController : ApiController
    {
        [HttpPost]
        [Route("api/AdminUser/update")]
        public HttpResponseMessage UpdateAdminUser(UserAdminDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                var data = UserAdminService.UpdateAdminUserService(user);
                return Request.CreateResponse(HttpStatusCode.Created, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/AdminUser/Login")]
        public HttpResponseMessage LoginAdminUser(UserAdminDTO user)
        {
            try
            {

                var data = UserAdminService.Authenticate(user.Email,user.Password);
                return Request.CreateResponse(HttpStatusCode.Created, data);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
