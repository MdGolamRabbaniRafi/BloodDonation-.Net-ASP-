using System;
using System.IO; // Include this for Directory operations
using System.Web;
using System.Web.Http;

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
    }
}
