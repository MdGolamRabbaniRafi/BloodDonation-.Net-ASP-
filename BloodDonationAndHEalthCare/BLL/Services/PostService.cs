
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BLL.DTO;

namespace BLL.Services
{
    public class PostService
    {
        public static PostDTO AddPostService(PostDTO post)
        {
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            var data = MapperClass.MapperPost();
            var mapped = data.Map<Post>(post);
            var postRepo = DataAccessFactory.PostData().Create(mapped);
            var data2 = MapperClass.MappedUser();
            var mapped2 = data2.Map<PostDTO>(postRepo);

            return mapped2;
        }
        public static PostDTO GetPost(int UserId)
        {
            var data = MapperClass.MapperPost();
            var getposts = DataAccessFactory.PostData().Read(UserId);
            var mapped = data.Map<User>(getposts);
            var data2 = MapperClass.MappedUser();
            var mapper2 = data2.Map<PostDTO>(mapped);

            return mapper2;
        }

    }
}