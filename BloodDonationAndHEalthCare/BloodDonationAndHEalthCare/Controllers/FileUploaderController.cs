using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using BLL.DTO;

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
                    // Define the path to the Uploads directory
                    var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

                    // Check if the Uploads directory exists
                    if (!Directory.Exists(uploadPath))
                    {
                        // If it doesn't exist, create the directory
                        Directory.CreateDirectory(uploadPath);
                    }

                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        // Save the file to the Uploads directory instead of the root directory
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
            switch (fileExtension.ToLowerInvariant())
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
                    return "application/octet-stream"; // Default for unknown extensions
            }
        }
    }
}
