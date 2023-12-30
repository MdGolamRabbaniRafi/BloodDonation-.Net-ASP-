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
<<<<<<< HEAD
=======
    using AutoMapper;
    using BLL.DTO;

>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
    public static class MapperClass
    {
        public static IMapper Mapped()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserAdminDTO, UserAdmin>();
                c.CreateMap<UserAdmin, UserAdminDTO>();
<<<<<<< HEAD


=======
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MappedUser()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<UserDTO, User>();
<<<<<<< HEAD
                c.CreateMap<User, UserDTO>();

=======
                c.CreateMap<User,UserDTO>();
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
<<<<<<< HEAD
        public static IMapper MappedDonation()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Donation, DonationDTO>();
                c.CreateMap<DonationDTO, Donation>();
            });

            var mapper = new Mapper(cfg);
            return mapper;
        }
=======
>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
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
<<<<<<< HEAD
=======

>>>>>>> 4ea6939d29cb0dd8d0f972c7551ebaa58f86e884
}
