using AutoMapper;
using BLL.DTO;
using BLL.DTOs;
using DAL.Models;

namespace BLL.Services
{
<<<<<<< HEAD
=======
    using AutoMapper;
    using BLL.DTO;

>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
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
               
=======
                c.CreateMap<User,UserDTO>();
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59
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
=======
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
    }
>>>>>>> 28f43027efb55e916f52aedf5d7dd16365682d59

            var mapper = new Mapper(cfg);
            return mapper;
        }
    }
}
