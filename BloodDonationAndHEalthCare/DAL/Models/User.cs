using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        //public string FileName { get; set; } 
        //public string FileContent { get; set; } 
        public string BloodGroup { get; set; }
        [ForeignKey("UserAdmin")]
        public int AdminId { get; set; }
        public virtual UserAdmin UserAdmin { get; set; }
    }
}
