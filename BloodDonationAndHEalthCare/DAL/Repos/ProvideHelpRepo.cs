using System.Collections.Generic;
using System.Linq;
using DAL.Interface;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class ProvideHelpRepo : IProvideHelp
    {
        public ProvideHelp Create(ProvideHelp obj)
        {
            using (var db = new DBContext())
            {
                db.ProvideHelps.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DBContext())
            {
                var entity = db.ProvideHelps.Find(id);
                if (entity != null)
                {
                    db.ProvideHelps.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<ProvideHelp> Read()
        {
            using (var db = new DBContext())
            {
                return db.ProvideHelps.ToList();
            }
        }

        public ProvideHelp Read(int id)
        {
            using (var db = new DBContext())
            {
                return db.ProvideHelps.Find(id);
            }
        }

        public ProvideHelp Update(ProvideHelp obj)
        {
            using (var db = new DBContext())
            {
                var existingEntity = db.ProvideHelps.Find(obj.Id);
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
