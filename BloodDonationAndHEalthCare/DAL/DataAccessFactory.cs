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
        public static IToken<Token, string, Token,bool> TokenData()
        {
            return new TokenRepo();
        }


        public static IDonation DonationData()
        {
            return new DonationRepo();
        }
<<<<<<< HEAD
        public static IPost<Post, int, Post> PostData()
        {
            return new PostRepo();
=======
        public static IPost<Post,int , Post> PostData()
        {
            return new PostRepo();


     
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
        }

        public static IHelpPost<HelpPost, int, HelpPost> HelpPostData()
        {
            return new HelpPostRepo();
        }
        public static IFile<File, int> FileData()
        {
            return new FileRepo();

<<<<<<< HEAD
=======
        }
        public static IBloodDonationCampaign BloodDonationCampaignData()
        {
            return new BloodDonationCampaignRepo();
        }
        public static IProvideHelp ProvideHelpData() 
        { 
            return new ProvideHelpRepo();
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
        }
    }
}
