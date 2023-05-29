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
    public class StaffDATests
    {
        [TestMethod()]
        public void addStaffTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            StaffDA staffDA = new StaffDA(info);

            staffDA.addStaff(new Person(1, "Nemisis", 25, "neme@mail.com", "Saint"));

            NpgsqlCommand command = new NpgsqlCommand(staffDA.queryGetStaff(3), staffDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Person staff = new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            reader.Close();

            Assert.AreEqual(staff.Name, "Nemisis");
            Assert.AreEqual(staff.Id, 3);
        }
        [TestMethod()]
        public void getStaffTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            StaffDA staffDA = new StaffDA(info);

            Person? staff = staffDA.getStaff(1);
            Assert.IsNotNull(staff);
            Assert.AreEqual(staff.Name, "Alex");
        }
        [TestMethod()]
        public void removeStaffTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            StaffDA staffDA = new StaffDA(info);

            staffDA.removeStaff(3);
            NpgsqlCommand command = new NpgsqlCommand(staffDA.queryGetStaff(3), staffDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();

        }
        [TestMethod()]
        public void updateStaffTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            StaffDA staffDA = new StaffDA(info);

            staffDA.updateStaff(2, "Comando", 27, "Coman@gmail.com", "London");

            NpgsqlCommand command = new NpgsqlCommand(staffDA.queryGetStaff(2), staffDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Person staff = new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            reader.Close();
            Assert.AreEqual(staff.Name, "Comando");
        }
    }
}