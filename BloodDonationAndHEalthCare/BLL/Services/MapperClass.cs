using AutoMapper;
using BLL.DTO;
using BLL.DTOs;
using DAL.Models;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc

namespace BLL.Services
{
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
<<<<<<< HEAD

                c.CreateMap<User, UserDTO>();

                c.CreateMap<User,UserDTO>();
=======
                c.CreateMap<User, UserDTO>();
                c.CreateMap<User, UserDTO>();
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
            });
            var mapper = new Mapper(cfg);
            return mapper;
        }

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
<<<<<<< HEAD
=======

>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
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
        public static IMapper MappedBloodDonationCampaign()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<BloodDonationCampaign, BloodDonationCampaignDTO>();
                c.CreateMap<BloodDonationCampaignDTO, BloodDonationCampaign>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
        public static IMapper MapperProvideHelp()
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProvideHelp, ProvideHelpDTO>();
                c.CreateMap<ProvideHelp, ProvideHelpDTO>();
            });
            var mapper = new Mapper(cfg);

            return mapper;
        }
    }
<<<<<<< HEAD

=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
}
