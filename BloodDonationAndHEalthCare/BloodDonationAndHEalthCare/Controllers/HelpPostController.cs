﻿using BLL.DTO;
using BLL.Services;
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
    public class HelpPostController : ApiController
    {
        [HttpPost]
        [Route("api/helppost/add")]
        public HttpResponseMessage AddHelpPost(HelpPostDTO helppost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var data = HelpPostService.AddHelpPostService(helppost);
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


        [HttpGet]
        [Route("api/helppost/{HelpPostId}")]
        public HttpResponseMessage GetHelpPost(int HelpPostId)
        {
            try
            {
                var data = HelpPostService.GetHelpPost(HelpPostId);

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
        [HttpGet]
        [Route("api/post/GetAllHelpPosts")]
        public HttpResponseMessage GetAllHelpPosts()
        {
            try
            {
                var allHelpPosts = HelpPostService.GetAllHelpPosts();

                if (allHelpPosts != null && allHelpPosts.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, allHelpPosts);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No posts found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/helppost/update/{HelpPostId}")]
        public HttpResponseMessage UpdateHelpPost(int HelpPostId, [FromBody] HelpPostDTO helppost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var updatedHelpPost = HelpPostService.UpdateHelpPostService(HelpPostId, helppost);

                if (updatedHelpPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, updatedHelpPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Post not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/helpPost/delete/{HelpPostId}")]
        public HttpResponseMessage DeleteHelpPost(int HelpPostId)
        {
            try
            {
                var isSuccess = HelpPostService.DeleteHelpPostService(HelpPostId);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Help Post deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Post not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
    }
}
