using AutoMapper;
using AutoMapper.QueryableExtensions.Impl;
using BLL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    using AutoMapper;
    using BLL.DTO;

    public static class MapperClass
    {
        public static IMapper Mapped()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserAdminDTO, UserAdmin>();
                c.CreateMap<UserAdmin, UserAdminDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedUser()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
                c.CreateMap<User,UserDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MapperPost()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<PostDTO, Post>();
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;

        }
        public static IMapper MapperFile()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FileDTO, File>();
                c.CreateMap<File, FileDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper;

        }
    }

}
