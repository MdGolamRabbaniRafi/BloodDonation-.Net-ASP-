using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FileRepo : Repo, IFile<File, int>
    {
        public File Create(File obj)
        {
            db.Files.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public File ReadAdminFile(int id)
        {
            var file = db.Files
                         .Where(f => f.UserId == id && f.UserType == "Admin")
                         .FirstOrDefault();
            if (file == null) return null;

            return file;
        }
        public File ReadUserFile(int id)
        {
<<<<<<< HEAD
            var file = db.Files
                         .Where(f => f.UserId == id && f.UserType == "User")
                         .FirstOrDefault();
            if (file == null) return null;
=======
            var file = (from f in db.Files
                        where f.UserId == id && f.UserType == "User"
                        select f).FirstOrDefault();

            if (file == null)
            {
                // Handle the case where file is null
                return null;
            }
>>>>>>> ce7bbdb30af06c94d0ca44808510a4c1ba9f765e

            return file;
        }

    }
}
