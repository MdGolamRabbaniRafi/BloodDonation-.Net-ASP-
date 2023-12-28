<<<<<<< HEAD
<<<<<<< Development
=======
<<<<<<< HEAD
>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a
﻿using System;
=======
﻿using BLL.DTO;
using System;
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
<<<<<<< HEAD
=======
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

>>>>>>> local
=======
<<<<<<< HEAD
using BLL.DTO;
=======
using System.Web.Http.Cors;
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a

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
<<<<<<< HEAD
<<<<<<< Development
=======
<<<<<<< HEAD
>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a
                    // Define the path to the Uploads directory
                    var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

                    // Check if the Uploads directory exists
                    if (!Directory.Exists(uploadPath))
                    {
                        // If it doesn't exist, create the directory
=======
                    var uploadPath = HttpContext.Current.Server.MapPath("~/Uploads");

                    if (!Directory.Exists(uploadPath))
                    {
<<<<<<< HEAD
>>>>>>> local
=======
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a
                        Directory.CreateDirectory(uploadPath);
                    }

                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
<<<<<<< HEAD
<<<<<<< Development
                        // Save the file to the Uploads directory instead of the root directory
=======
>>>>>>> local
=======
<<<<<<< HEAD
                        // Save the file to the Uploads directory instead of the root directory
=======
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a
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
<<<<<<< HEAD
<<<<<<< Development
=======
        [Logged]
=======

>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a
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
<<<<<<< HEAD
>>>>>>> local
    }
}
=======
    }
<<<<<<< HEAD
    
}
=======
}
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
>>>>>>> 02aab3c1c013bd5f9f8ddf8bbf77a02bc66b869a
