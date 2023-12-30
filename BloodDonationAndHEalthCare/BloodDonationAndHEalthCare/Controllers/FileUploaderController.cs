<<<<<<< HEAD
using BLL.DTO;
=======
﻿using BLL.DTO;
<<<<<<< HEAD
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
=======
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
>>>>>>> 86b45632962edcc7bce0a3f9210ff0cadbbb8882
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FileUploaderController : ApiController
    {
        [HttpPost]
        [Logged]
        [Route("api/UploadFile")]
        public IHttpActionResult UploadFile()
        {
            try
            {
                var token = ActionContext.Request.Headers.Authorization;
                var httpRequest = HttpContext.Current.Request;
                FileDTO fileDTO = new FileDTO();
                int count = 0;
                if (httpRequest.Files.Count > 0)
                {
                    var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = Path.Combine(uploadPath, postedFile.FileName);
                        fileDTO.FileName=postedFile.FileName;
                        var fileService = FileUploaderService.UploadFile(fileDTO, token.ToString());
                        if(fileService)
                        {
                            count++;
                        }
                        postedFile.SaveAs(filePath);

                    }
                    if (count > 0)
                    {
                        return Ok("File uploaded successfully");
                    }
                    else
                    {
                        return InternalServerError();
                    }

                }

                else
                {
                    return BadRequest("No file received");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Logged]
        [Route("api/GetFile")]
        public IHttpActionResult GetFile(FileDTO fileName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileName.FileName))
                {
                    return BadRequest("File name is required.");
                }

                var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");
                var filePath = Path.Combine(uploadPath, fileName.FileName);

                if (File.Exists(filePath))
                {
                    byte[] fileBytes = File.ReadAllBytes(filePath);

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ByteArrayContent(fileBytes);

                    // Determine content type based on known file extension
                    var fileExtension = Path.GetExtension(fileName.FileName);
                    if (!string.IsNullOrEmpty(fileExtension))
                    {
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue(GetContentTypeFromExtension(fileExtension));
                    }

                    return ResponseMessage(response);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private string GetContentTypeFromExtension(string fileExtension)
        {
            switch (fileExtension.ToLower())
            {
                case ".txt":
                    return "text/plain";
                case ".html":
                    return "text/html";
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                default:
                    return "application/octet-stream";
            }
        }
    }
}