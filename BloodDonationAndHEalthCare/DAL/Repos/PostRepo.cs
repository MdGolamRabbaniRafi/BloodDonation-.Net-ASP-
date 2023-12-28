using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IPost<Post, int, Post>
    {
        public Post Create(Post obj)
        {
            db.Posts.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int obj)
        {
            throw new NotImplementedException();
        }

        public List<Post> Read()
        {
           return db.Posts.ToList();
        }

        public Post Read(int id)
        {
            throw new NotImplementedException();
        }

        public string Read(string Email)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post obj)
        {
            var ex = Read(obj.UserId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        



        }
    }
