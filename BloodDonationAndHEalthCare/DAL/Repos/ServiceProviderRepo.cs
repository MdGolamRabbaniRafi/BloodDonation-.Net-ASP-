using DAL.Interfaces;
using DAL.Models;
using System.Linq;
using System.Collections.Generic;

namespace DAL.Repos
{
    internal class ServiceProviderRepo : Repo, IRepo<ServiceProvider, int, ServiceProvider>, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.Services.FirstOrDefault(s => s.Email.Equals(email) &&
                                                             s.Password.Equals(password));
            return data != null;
        }

        public ServiceProvider Create(ServiceProvider obj)
        {
            db.Services.Add(obj);
            if (db.SaveChanges() > 0)
                return obj;

            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            if (ex != null)
            {
                db.Services.Remove(ex);
                return db.SaveChanges() > 0;
            }

            return false;
        }

        public List<ServiceProvider> Read()
        {
            return db.Services.ToList();
        }

        public ServiceProvider Read(int id)
        {
            return db.Services.Find(id);
        }

        public ServiceProvider Update(ServiceProvider obj)
        {
            var ex = Read(obj.Id);
            if (ex != null)
            {
                db.Entry(ex).CurrentValues.SetValues(obj);
                if (db.SaveChanges() > 0)
                    return obj;
            }

            return null;
        }
    }
}
