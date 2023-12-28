﻿using BLL.DTO;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BloodDonationAndHEalthCare.Auth;


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
                var httpRequest = HttpContext.Current.Request;
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
                        postedFile.SaveAs(filePath);
                    }
                    return Ok("File uploaded successfully");

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
        [Logged]
        [HttpGet]
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