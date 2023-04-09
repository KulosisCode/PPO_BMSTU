using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Tests;
using HotelBooking;

namespace HotelBooking.Tests
{
    public class TestStaffRepo : IStaffRepository
    {
        private List<Person> staffs;
        public TestStaffRepo(List<Person> staffs)
        {
            this.staffs = staffs;
        }
        public void addStaff(Person person)
        {
            int N = this.staffs.Count;
            this.staffs.Add(new Person(N + 1, person.Id_login, person.Name, person.Age, person.Email, person.Address));
        }
        public Person getStaff(int id)
        {
            foreach (Person staff in this.staffs)
                if (staff.Id == id)
                    return staff;
            return new Person();
        }
        public void updateStaff(int id, string name, int age, string email, string address)
        {
            foreach (Person staff in this.staffs)
                if (staff.Id == id)
                {
                    staff.Name = name;
                    staff.Age = age;
                    staff.Email = email;
                    staff.Address = address;
                }
        }
        public void removeStaff(int id)
        {
            List<Person> newstaffs = new List<Person>();
            foreach (Person staff in this.staffs)
                if (staff.Id != id)
                    newstaffs.Add(staff);
            this.staffs = newstaffs;
        }
    }

    [TestClass()]
    public class StaffManagerTests
    {
        [TestMethod()]
        public void addStaffTest()
        {
            List<Person> staff = new List<Person>();
            staff.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            staff.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestStaffRepo teststaff = new TestStaffRepo(staff);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            StaffManager staffManager = new StaffManager(teststaff, testuser);

            staffManager.addStaff(new Person(2, "Ayaka", 18, "ayaka@mail.ru", "Saint"));

            Person staff_ = teststaff.getStaff(3);
            Assert.AreEqual(staff_.Name, "Ayaka");

        }
        [TestMethod()]
        public void getGuestTest()
        {
            List<Person> staff = new List<Person>();
            staff.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            staff.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestStaffRepo teststaff = new TestStaffRepo(staff);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            StaffManager staffManager = new StaffManager(teststaff, testuser);

            Person staff_ = staffManager.getStaff(1);
            Assert.AreEqual(staff_.Name, "Alex");
        }
        [TestMethod()]
        public void updateGuest()
        {
            List<Person> staff = new List<Person>();
            staff.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            staff.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestStaffRepo teststaff = new TestStaffRepo(staff);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            StaffManager staffManager = new StaffManager(teststaff, testuser);

            staffManager.updateStaff(1, "Nahida", 20, "alex@gmail.com", "London");

            Person staff_ = staffManager.getStaff(1);
            Assert.AreEqual(staff_.Name, "Nahida");
        }

        [TestMethod()]
        public void removeGuest()
        {
            List<Person> staff = new List<Person>();
            staff.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            staff.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestStaffRepo teststaff = new TestStaffRepo(staff);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            StaffManager staffManager = new StaffManager(teststaff, testuser);

            staffManager.removeStaff(1);

            Person staff_ = teststaff.getStaff(1);
            Assert.AreEqual(staff_.Id, -1);
            Assert.AreEqual(staff_.Name, string.Empty);
        }
    }
}