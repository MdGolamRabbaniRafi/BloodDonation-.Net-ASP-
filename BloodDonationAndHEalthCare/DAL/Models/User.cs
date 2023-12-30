using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        //public string FileName { get; set; } 
        //public string FileContent { get; set; } 
        public string BloodGroup { get; set; } // Nullable string

        public string UserType { get; set; } // Nullable string

        [ForeignKey("UserAdmin")]
<<<<<<< HEAD
        public int AdminId { get; set; }
        public virtual UserAdmin UserAdmin { get; set; }

=======
        public int? AdminId { get; set; } // Nullable int
        public virtual UserAdmin UserAdmin { get; set; } // Nullable UserAdmin
>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0

        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new List<Post>();
        }

    }
}
