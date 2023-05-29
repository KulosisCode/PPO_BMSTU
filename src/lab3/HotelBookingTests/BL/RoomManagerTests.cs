using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Tests
{
    public class TestRoomRepo : IRoomRepository //TestRoomRepos
    {
        public List<Room> rooms;
        public TestRoomRepo(List<Room> rooms)
        {
            this.rooms = rooms;
        }
        public void addRoom(Room room)
        {
            int N = this.rooms.Count;
            this.rooms.Add(new Room(N + 1, room.Number, room.Status));// xóa 1 elem sau đó add sẽ gây ra sai id???
        }
        public Room? getRoom(int id_room)
        {
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room == id_room)
                    return tmpRoom;
            return null;
        }
        //update
        public void updateRoom(int id_room)
        {
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room == id_room)
                {
                    if (tmpRoom.Status == RoomStatus.Free)
                    {
                        tmpRoom.Status = RoomStatus.Busy;
                    }
                    else
                    {
                        tmpRoom.Status = RoomStatus.Free;
                    }
                }

        }
        public void removeRoom(int id_room)
        {
            List<Room> newRoom = new List<Room>();
            foreach (Room tmpRoom in this.rooms)
                if (tmpRoom.Id_room != id_room)
                    newRoom.Add(tmpRoom);
            this.rooms = newRoom;
        }
        public List<Room> getRoomList()
        {
            return this.rooms;
        }
    }
    [TestClass()]
    public class RoomManagerTests 
    {
        
        [TestMethod()]
        public void getRoomTest()
        {

            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomStatus.Free),
                new Room(2, 428, RoomStatus.Free),
                new Room(3, 101, RoomStatus.Busy)
            };
            TestRoomRepo testRoom = new TestRoomRepo(rooms);
            RoomManager roomManager = new RoomManager(testRoom);

            Room room = roomManager.getRoom(1);
            Assert.AreEqual(room.Id_room, 1);
            Assert.AreEqual(room.Number, 528);
            Assert.AreEqual(room.Status, RoomStatus.Free);
        }
        [TestMethod()]
        public void addRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomStatus.Free),
                new Room(2, 428, RoomStatus.Free),
                new Room(3, 101, RoomStatus.Busy)
            };
            TestRoomRepo testRoom = new TestRoomRepo(rooms);
            RoomManager roomManager = new RoomManager(testRoom);

            testRoom.addRoom(new Room(312, RoomStatus.Free));
            Room room = roomManager.getRoom(4);
            Assert.AreEqual(room.Id_room, 4);
            Assert.AreEqual(room.Number, 312);
            Assert.AreEqual(room.Status, RoomStatus.Free);
        }
        [TestMethod()]
        public void removeRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomStatus.Free),
                new Room(2, 428, RoomStatus.Free),
                new Room(3, 101, RoomStatus.Busy)
            };
            TestRoomRepo testRoom = new TestRoomRepo(rooms);
            RoomManager roomManager = new RoomManager(testRoom);

            roomManager.removeRoom(2);
            Room? room = testRoom.getRoom(2);

            Assert.AreEqual(room, null);
        }
        [TestMethod()]
        public void updateRoomTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomStatus.Free),
                new Room(2, 428, RoomStatus.Free),
                new Room(3, 101, RoomStatus.Busy)
            };
            TestRoomRepo testRoom = new TestRoomRepo(rooms);
            RoomManager roomManager = new RoomManager(testRoom);

            roomManager.updateRoom(1);
            Room? room = testRoom.getRoom(1);

            Assert.AreEqual(room.Status, RoomStatus.Busy);
        }
        [TestMethod()]
        public void getRoomListTest()
        {
            List<Room> rooms = new List<Room>
            {
                new Room(1, 528, RoomStatus.Free),
                new Room(2, 428, RoomStatus.Free),
                new Room(3, 101, RoomStatus.Busy)
            };
            TestRoomRepo testRoom = new TestRoomRepo(rooms);
            RoomManager roomManager = new RoomManager(testRoom);

            List<Room> allRooms = roomManager.getRoomList();
            Assert.AreEqual(allRooms.Count, 3);
        }
    }
}