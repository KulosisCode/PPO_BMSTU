using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using HotelBookingTests.DA;

namespace HotelBooking.Tests
{
    [TestClass()]
    public class RoomDATests
    {
        [TestMethod()]
        public void getRoomTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RoomDA roomDA = new RoomDA(info);

            Room? room = roomDA.getRoom(1);
            Assert.IsNotNull(room);
            Assert.AreEqual(room.Id_room, 1);
            Assert.AreEqual(room.Number, 102);
        }
        [TestMethod()]
        public void getRoomFailTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RoomDA roomDA = new RoomDA(info);

            Assert.IsNull(roomDA.getRoom(999));
        }
        [TestMethod()]
        public void addRoomTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RoomDA roomDA = new RoomDA(info);

            roomDA.addRoom(new Room(413, RoomStatus.Free));

            NpgsqlCommand command = new NpgsqlCommand(roomDA.queryGetRoom(3), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomStatus)Enum.Parse(typeof(RoomStatus), reader.GetString(2)));
            reader.Close();

            Assert.AreEqual(room.Number, 413);
            Assert.AreEqual(room.Status , RoomStatus.Free);
        }
        [TestMethod()]
        public void getRoomListTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RoomDA roomDA = new RoomDA(info);
            List<Room> allRoom = roomDA.getRoomList();
            Assert.AreEqual(allRoom.Count, 3);
        }
        [TestMethod()]
        public void removeRoomTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RoomDA roomDA = new RoomDA(info);

            roomDA.removeRoom(3);
            NpgsqlCommand command = new NpgsqlCommand(roomDA.queryGetRoom(3), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }
        [TestMethod()]
        public void updateRoomTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RoomDA roomDA = new RoomDA(info);

            roomDA.updateRoom(2);
            NpgsqlCommand command = new NpgsqlCommand(roomDA.queryGetRoom(2), roomDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Room room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomStatus)Enum.Parse(typeof(RoomStatus), reader.GetString(2)));
            reader.Close();

            Assert.AreEqual(room.Status, RoomStatus.Free);
        }
    }
}