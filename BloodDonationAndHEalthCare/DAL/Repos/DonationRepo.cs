using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Security.Policy;
=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
using DAL.Interface;
using DAL.Models;

namespace DAL.Repos
{
<<<<<<< HEAD
    internal class DonationRepo : Repo, IDonation
=======
    internal class DonationRepo : IDonation
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
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
<<<<<<< HEAD
       
=======

>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
        public List<Donation> Read()
        {
            using (var db = new DBContext())
            {
                return db.Donations.ToList();
            }
        }
<<<<<<< HEAD
        public List<Donation> ReadAccept()
        {
            
          
            var a = (from b in db.Donations where b.IsApproved == true select b).ToList();
                
          
            return a;
        }
=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc

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
<<<<<<< HEAD

=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
