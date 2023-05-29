using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingTests.DA;
using Npgsql;

namespace HotelBooking.Tests
{
    [TestClass()]
    public class GuestDATests
    {
        [TestMethod()]
        public void addGuestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            GuestDA guestDA = new GuestDA(info);

            guestDA.addGuest(new Person(1, "Nemisis", 25, "neme@mail.com", "Saint"));

            NpgsqlCommand command = new NpgsqlCommand(guestDA.queryGetGuest(3), guestDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Person guest = new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            reader.Close();

            Assert.AreEqual(guest.Name, "Nemisis");
            Assert.AreEqual(guest.Id, 3);
        }
        [TestMethod()]
        public void getGuestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            GuestDA guestDA = new GuestDA(info);

            Person? guest = guestDA.getGuest(1);
            Assert.IsNotNull(guest);
            Assert.AreEqual(guest.Name, "Alex");
        }
        [TestMethod()]
        public void removeGuestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            GuestDA guestDA = new GuestDA(info);

            guestDA.removeGuest(3);
            NpgsqlCommand command = new NpgsqlCommand(guestDA.queryGetGuest(3), guestDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();

        }
        [TestMethod()]
        public void updateGuestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            GuestDA guestDA = new GuestDA(info);

            guestDA.updateGuest(1, "Comando", 27, "Coman@gmail.com", "London");

            NpgsqlCommand command = new NpgsqlCommand(guestDA.queryGetGuest(1), guestDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Person guest = new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            reader.Close();
            Assert.AreEqual(guest.Name, "Comando");
        }
    }
}