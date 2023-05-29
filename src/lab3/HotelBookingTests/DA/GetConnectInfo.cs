using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking;

namespace HotelBookingTests.DA
{
    public static class GetConnectInfo
    {
        public static ConnectionDA getinfo()
        {
            return new ConnectionDA("postgres", "localhost", "my_ppo", "haoasd", 5432);
        }
    }
}
