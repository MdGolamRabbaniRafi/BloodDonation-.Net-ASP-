using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserAdminService
    {
        public static UserAdminDTO UpdateAdminUserService(UserAdminDTO admin)
        {
            var data = MapperClass.Mapped();
            var mapped = data.Map<UserAdmin>(admin);
            string hashedPassword = PasswordHasher.HashPassword(admin.Password);
            mapped.Password = hashedPassword; var userRepo=DataAccessFactory.UserAdminData().Update(mapped);
            var data2 = MapperClass.Mapped();
            var mapped2 = data2.Map<UserAdminDTO>(userRepo);

            return mapped2;
        }
        public static bool Authenticate(string email, string pass)
        {
            string hashedPassword = PasswordHasher.HashPassword(pass);

            var data = DataAccessFactory.AuthData().Authenticate(email, hashedPassword);
            return data;
        }
    }
}
