using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelBooking.Tests
{
    public class TestGuestRepo : IGuestRepository
    {
        private List<Person> guests;
        public TestGuestRepo(List<Person> guests) 
        {   
            this.guests = guests;
        }
        public void addGuest(Person person)
        {
            int N = this.guests.Count;
            this.guests.Add(new Person(N + 1, person.Id_login,person.Name, person.Age, person.Email, person.Address));
        }
        public Person getGuest(int id)
        {
            foreach (Person guest in this.guests) 
                if (guest.Id == id)
                    return guest;
            return new Person();
        }
        public void updateGuest(int id, string name, int age, string email, string address)
        {
            foreach (Person guest in this.guests)
                if (guest.Id == id)
                {
                    guest.Name = name;
                    guest.Age = age;
                    guest.Email = email;
                    guest.Address = address;
                }
        }
        public void removeGuest(int id)
        {
            List<Person> newguests = new List<Person>();
            foreach (Person guest in this.guests)
                if (guest.Id != id)
                    newguests.Add(guest);
            this.guests = newguests;
        }
    }
    [TestClass()]
    public class GuestManagerTests
    {
        [TestMethod()]
        public void addGuestTest()
        {
            List<Person> guest = new List<Person>();
            guest.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            guest.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestGuestRepo testguest = new TestGuestRepo(guest);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            GuestManager guestManager = new GuestManager(testguest, testuser);

            guestManager.addGuest(new Person(2,"Ayaka", 18, "ayaka@mail.ru", "Saint"));

            Person guest_ = testguest.getGuest(3);
            Assert.AreEqual(guest_.Name, "Ayaka");

        }
        [TestMethod()]
        public void getGuestTest()
        {
            List<Person> guest = new List<Person>();
            guest.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            guest.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestGuestRepo testguest = new TestGuestRepo(guest);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            GuestManager guestManager = new GuestManager(testguest, testuser);

            Person guest_ = guestManager.getGuest(1);
            Assert.AreEqual(guest_.Name, "Alex");
        }
        [TestMethod()]
        public void updateGuestTest()
        {
            List<Person> guest = new List<Person>();
            guest.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            guest.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestGuestRepo testguest = new TestGuestRepo(guest);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            GuestManager guestManager = new GuestManager(testguest, testuser);

            guestManager.updateGuest(1, "Nahida", 20, "alex@gmail.com", "London");

            Person guest_ =  guestManager.getGuest(1);
            Assert.AreEqual(guest_.Name, "Nahida");
        }

        [TestMethod()] 
        public void removeGuestTest()
        {
            List<Person> guest = new List<Person>();
            guest.Add(new Person(1, 1, "Alex", 20, "alex@gmail.com", "London"));
            guest.Add(new Person(2, 3, "Mona", 21, "mona@gmail.com", "Mondstadt"));

            TestGuestRepo testguest = new TestGuestRepo(guest);
            TestUserRepo testuser = new TestUserRepo(Obj.users);
            GuestManager guestManager = new GuestManager(testguest, testuser);

            guestManager.removeGuest(1);

            Person guest_ = testguest.getGuest(1);
            Assert.AreEqual(guest_.Id, -1);
            Assert.AreEqual(guest_.Name, string.Empty);
        }
    }
}