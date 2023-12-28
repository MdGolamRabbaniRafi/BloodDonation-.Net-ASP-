using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repos
{
    internal class DonationRepo : IDonation
    {
        public Donation Create(Donation obj)
        {
            using (var db = new DBContext())
            {
                db.Donations.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DBContext())
            {
                var entity = db.Donations.Find(id);
                if (entity != null)
                {
                    db.Donations.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<Donation> Read()
        {
            using (var db = new DBContext())
            {
                return db.Donations.ToList();
            }
        }

        public Donation Read(int id)
        {
            using (var db = new DBContext())
            {
                return db.Donations.Find(id);
            }
        }

        public Donation Update(Donation obj)
        {
            using (var db = new DBContext())
            {
                var existingEntity = db.Donations.Find(obj.Id);
                if (existingEntity != null)
                {
                    db.Entry(existingEntity).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                    return obj;
                }
                return null;
            }
        }
    }
}
