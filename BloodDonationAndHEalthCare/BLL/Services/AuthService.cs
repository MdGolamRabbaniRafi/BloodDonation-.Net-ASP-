using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string Email, string Password)
        {
            var res = DataAccessFactory.AuthDataUser().Authenticate(Email, Password);
            if (res)
            {
                var token = new Token();
                token.UserId = Email;
                token.CreateAt = DateTime.Now;
                token.Tkey = Guid.NewGuid().ToString();
                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }
        public static bool isTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if (extk != null && extk.UpdateAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            extk.UpdateAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;
        }
    }
}
