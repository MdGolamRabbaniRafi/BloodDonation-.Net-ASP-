using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static UserDTO UpdateUserService(UserDTO user)
        {
            var data = MapperClass.MappedUser();
            var mapped = data.Map<User>(user);
            string hashedPassword = PasswordHasher.HashPassword(user.Password);
            mapped.Password = hashedPassword; var userRepo = DataAccessFactory.UserData().Update(mapped);
            var data2 = MapperClass.MappedUser();
            var mapped2 = data2.Map<UserDTO>(userRepo);

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
