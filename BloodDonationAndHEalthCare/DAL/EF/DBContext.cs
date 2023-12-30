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
=======
        public DbSet<Post>Posts { get; set; }
        public DbSet<File> Files { get; set; }
>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0

    }
}
