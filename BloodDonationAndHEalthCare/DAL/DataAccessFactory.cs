using DAL.Interface;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<UserAdmin, int, UserAdmin> UserAdminData()
        {
            return new UserAdminRepo();
        }
        public static IUser<User, int, User,string> UserData()
        {
            return new UserRepo();
        }
        public static IAuth<bool> AuthData()
        {
            return new UserAdminRepo();
        }
        public static IAuth<bool> AuthDataUser()
        {
            return new UserRepo();
        }
        public static IAuth<bool> AuthDataUserAdmin()
        {
            return new UserAdminRepo();
        }
        public static IToken<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
<<<<<<< HEAD

        public static IDonation DonationData()
        {
            return new DonationRepo();
        }
        public static IPost<Post,int , Post> PostData()
        {
            return new PostRepo();

=======
        public static IPost<Post,int , Post> PostData()
        {
            return new PostRepo();
        }
        public static IFile<File, int> FileData()
        {
            return new FileRepo();
>>>>>>> 23c3e0f56e572792f675bf5cdcac4001c46431a0
        }
    }
}
