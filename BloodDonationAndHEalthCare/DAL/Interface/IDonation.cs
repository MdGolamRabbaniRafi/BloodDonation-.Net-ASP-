using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IDonation
    {
        Donation Create(Donation obj);
        List<Donation> Read();
        Donation Read(int id);
        Donation Update(Donation obj);
        bool Delete(int id);
    }
}
