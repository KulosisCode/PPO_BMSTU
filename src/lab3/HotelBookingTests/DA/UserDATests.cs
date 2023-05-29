using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBookingTests.DA;
using Npgsql;

namespace HotelBooking.Tests
{
    [TestClass()]
    public class UserDATests
    {
        [TestMethod()]
        public void addUserTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            UserDA userDA = new UserDA(info);

            userDA.addUser("caption", "password", Role.None);

            NpgsqlCommand command = new NpgsqlCommand(userDA.queryGetUser(3), userDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (Role)Enum.Parse(typeof(Role), reader.GetString(3)));
            reader.Close();

            Assert.AreEqual(user.Login, "caption");
            Assert.AreEqual(user.ARole, Role.None);
            Assert.AreEqual(user.Id, 3);
        }
        [TestMethod()]
        public void getIdUserTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            UserDA userDA = new UserDA(info);

            int id = userDA.getIdUser("kulosis");
            Assert.AreEqual(id, 1);
        }
        [TestMethod()]
        public void getUserTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            UserDA userDA = new UserDA(info);

            User? user = userDA.getUser(1);
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Login, "kulosis");
        }
        [TestMethod()]
        public void getUserListTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            UserDA usersDA = new UserDA(info);

            List<User> users = usersDA.getUserList();
            Assert.AreEqual(users.Count, 3);
        }
        [TestMethod()]
        public void removeUserTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            UserDA userDA = new UserDA(info);

            userDA.removeUser(3);
            NpgsqlCommand command = new NpgsqlCommand(userDA.queryGetUser(3), userDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }
        [TestMethod()]
        public void updateUserTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            UserDA userDA = new UserDA(info);

            userDA.updateUser(2, "passpass", Role.Staff);
            NpgsqlCommand command = new NpgsqlCommand(userDA.queryGetUser(2), userDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (Role)Enum.Parse(typeof(Role), reader.GetString(3)));
            reader.Close();

            Assert.AreEqual(user.Password, "passpass");
        }
    }
}