using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DBContext : DbContext
    {
        public DbSet<UserAdmin> UserAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
<<<<<<< HEAD

        public DbSet<Post>Posts { get; set; }
<<<<<<< HEAD
        public DbSet<File> Files { get; set; }

=======

=======
        public DbSet<Post>Posts { get; set; }
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
>>>>>>> 86b45632962edcc7bce0a3f9210ff0cadbbb8882
    }
}
