using BLL.DTOs;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminUserController : ApiController
    {
        [Logged]
        [AdminCheck]
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

        [Logged]
        [HttpPost]
        [Route("api/AdminUser/Login")]
        public HttpResponseMessage LoginAdminUser(UserAdminDTO user)
        {
            try
            {
                var data = UserAdminService.Authenticate(user.Email, user.Password);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
<<<<<<< HEAD
        }

=======

        }
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
        [Logged]
        [AdminCheck]
        [HttpGet]
        [Route("api/AdminUser/{userId}")]
        public HttpResponseMessage GetUser(int userId)
        {
            try
            {
                var data = UserAdminService.GetUser(userId);

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
<<<<<<< HEAD

        [Logged]
        [AdminCheck]
=======
        [Logged]
        [AdminCheck]

>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
        [HttpPost]
        [Route("api/AdminUser/{userId}")]
        public HttpResponseMessage UpdateUser(int userId, [FromBody] UserDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var updatedUser = UserAdminService.UpdateUserService(userId, user);

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
<<<<<<< HEAD
=======

>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
        [Logged]
        [AdminCheck]
        [Route("api/AdminUser/{userId}")]
        public HttpResponseMessage DeleteUser(int userId)
        {
            try
            {
                var isSuccess = UserAdminService.DeleteUserService(userId);

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
        [Logged]
        [AdminCheck]
<<<<<<< HEAD
        [Route("api/AdminUser/addUser/{token}")]
        public HttpResponseMessage AddUser(UserDTO user, string token)
=======
        [Route("api/AdminUser/addUser")]
        public HttpResponseMessage AddUser(UserDTO user)
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
<<<<<<< HEAD

                // var token = ActionContext.Request.Headers.Authorization;
                var data = UserAdminService.AddUserService(user);
=======
                var token = ActionContext.Request.Headers.Authorization;

                var data = UserAdminService.AddUserService(user,token.ToString());
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/AdminUser/Signup")]
        public HttpResponseMessage AddAdminUser(UserAdminDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var data = UserAdminService.AddAdminUserService(user);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
