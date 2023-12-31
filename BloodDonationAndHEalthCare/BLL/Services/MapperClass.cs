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

>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0
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
>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0
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
>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0
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
>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0
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
<<<<<<< HEAD
        public static IMapper MapperHelpPost()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<HelpPostDTO, HelpPost>();
                c.CreateMap<HelpPost, HelpPostDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;

        }
=======
<<<<<<< HEAD
    }
=======
>>>>>>> e69771a790e946bf84321f295a58a4869f4ee2e0
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

>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0
}
