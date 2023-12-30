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
                         .Where(f => f.ID == id && f.UserType == "Admin")
                         .FirstOrDefault();
            if(file == null) return null;

            return file;
        }
        public File ReadUserFile(int id)
        {
            var file = db.Files
                         .Where(f => f.ID == id && f.UserType == "User")
                         .FirstOrDefault();
            if (file == null) return null;

            return file;
        }

    }
}
