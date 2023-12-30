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
=======
<<<<<<< HEAD
        public int AdminId { get; set; }
        public virtual UserAdmin UserAdmin { get; set; }

=======
<<<<<<< HEAD
>>>>>>> 86b45632962edcc7bce0a3f9210ff0cadbbb8882
        public int? AdminId { get; set; } // Nullable int
        public virtual UserAdmin UserAdmin { get; set; } // Nullable UserAdmin
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884

        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new List<Post>();
        }

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
        public int? AdminId { get; set; }
        public virtual UserAdmin UserAdmin { get; set; }
>>>>>>> 08eca8d5d2bd9d9146729129be0f33bc28d9b71c
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
>>>>>>> 86b45632962edcc7bce0a3f9210ff0cadbbb8882
    }
}
