using DAL.Models;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Security.Policy;
=======
using Stripe.Terminal;
using System.Collections.Generic;
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc

namespace DAL.Interface
{
    public interface IDonation
    {
        Donation Create(Donation obj);
        List<Donation> Read();
        Donation Read(int id);
<<<<<<< HEAD
        List<Donation> ReadAccept();
=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
        Donation Update(Donation obj);
        bool Delete(int id);
    }
}
<<<<<<< HEAD

=======
>>>>>>> 4d7f619b2c5c0c430ba731d77ebc23bb23b68adc
