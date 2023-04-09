using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Tests
{
    public class TestUserRepo : IUserRepository
    {
        private List<User> users;
        public TestUserRepo(List<User> users) 
        {
            this.users = users;
        }
        public void addUser(string login, string password, Role role)
        {
            int N = this.users.Count;
            this.users.Add(new User(N+1, login, password, role));
        }
        public User getUser(int id) 
        {
            foreach (User user in this.users)
                if (user.Id == id)
                    return user;
            return new User(-1, string.Empty, string.Empty, Role.None);
        }
        public int getIdUser(string login)
        {
            foreach (User user in this.users)
                if (user.Login == login)
                    return user.Id;
            return -1;
        }
        public void removeUser(int id)
        {
            List<User> newUsers = new List<User>();
            foreach (User user in this.users)
                if (user.Id != id)
                    newUsers.Add(user);
            this.users = newUsers;
        }

        public void updateUser(int id, string password, Role role)
        {
            foreach (User user in this.users)
                if (user.Id == id)
                {
                    user.Password = password;
                    user.ARole = role;
                }
        }
        public List<User> getUserList()
        {
            return this.users;
        }
    }
    [TestClass()]
    public class UserManagerTests
    {
        [TestMethod()]
        public void addUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "Alex", "pass1", Role.Guest));
            users.Add(new User(2, "Tomy", "pass2", Role.Staff));

            TestUserRepo testUser = new TestUserRepo(users);
            UserManager userManager = new UserManager(testUser);

            userManager.addUser("John", "pass3", Role.Guest);

            User user = userManager.getUser(3);
            Assert.IsNotNull(user);
            Assert.AreEqual(3, user.Id);
            Assert.AreEqual("pass3", user.Password);
        }

        [TestMethod()]
        public void getUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "Alex", "pass1", Role.Guest));
            users.Add(new User(2, "Tomy", "pass2", Role.Staff));

            TestUserRepo testUser = new TestUserRepo(users);
            UserManager userManager = new UserManager(testUser);

            User user = userManager.getUser(1);
            Assert.IsNotNull(user);
            Assert.AreEqual("Alex", user.Login);
        }

        [TestMethod()]
        public void getIdUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "Alex", "pass1", Role.Guest));
            users.Add(new User(2, "Tomy", "pass2", Role.Staff));

            TestUserRepo testUser = new TestUserRepo(users);
            UserManager userManager = new UserManager(testUser);

            int id_user = userManager.getIdUser("Tomy");
            Assert.AreEqual(id_user, 2);
        }

        [TestMethod()]
        public void removeUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "Alex", "pass1", Role.Guest));
            users.Add(new User(2, "Tomy", "pass2", Role.Staff));

            TestUserRepo testUser = new TestUserRepo(users);
            UserManager userManager = new UserManager(testUser);

            userManager.removeUser(1);

            User user = testUser.getUser(1);
            Assert.AreEqual(user.Id, -1);
        }

        [TestMethod()]
        public void updateUserTest()
        {
            List<User> users = new List<User>();
            users.Add(new User(1, "Alex", "pass1", Role.Guest));
            users.Add(new User(2, "Tomy", "pass2", Role.Staff));

            TestUserRepo testUser = new TestUserRepo(users);
            UserManager userManager = new UserManager(testUser);

            userManager.updateUser(2, "password", Role.Guest);

            User user = userManager.getUser(2);
            Assert.AreEqual(user.Password, "password");
            Assert.AreEqual(user.ARole, Role.Guest);
        }
    }
}