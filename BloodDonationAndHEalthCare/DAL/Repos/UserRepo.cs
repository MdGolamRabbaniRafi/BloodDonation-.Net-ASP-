using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IRepo<User, int ,User>, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.Users.FirstOrDefault(u => u.Email.Equals(email) &&
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public User Create(User obj)
        {
            db.Users.Add(obj); 
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
           return  db.SaveChanges()>0;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
           var ex = Read(obj.UserId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;

        }
    }
}
