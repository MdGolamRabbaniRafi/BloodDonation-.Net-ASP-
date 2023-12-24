using System;
using System.IO; // Include this for Directory operations
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.DTO;
using System.Net.Http.Headers;

namespace BloodDonationAndHEalthCare.Controllers
{
    public class FileUploaderController : ApiController
    {
        [HttpPost]
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
                    string fileContent = File.ReadAllText(filePath);

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(fileContent);

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

        // Helper method to determine content type based on file extension
        private string GetContentTypeFromExtension(string fileExtension)
        {
            if (fileExtension.Equals(".txt", StringComparison.OrdinalIgnoreCase))
            {
                return "text/plain";
            }
            else if (fileExtension.Equals(".html", StringComparison.OrdinalIgnoreCase))
            {
                return "text/html";
            }
            else if (fileExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) || fileExtension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
            {
                return "image/jpeg";
            }
            else if (fileExtension.Equals(".png", StringComparison.OrdinalIgnoreCase))
            {
                return "image/png";
            }
            else
            {
                return "application/octet-stream"; // Default for unknown extensions
            }
        }





    }
}
