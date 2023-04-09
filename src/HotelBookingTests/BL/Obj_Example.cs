using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking;

namespace HotelBooking.Tests
{
    static public class Obj
    {
        public static List<Room> rooms = new List<Room>
        {
            new Room(1, 102, RoomStatus.Free),
            new Room(2, 150, RoomStatus.Busy),
            new Room(3, 450, RoomStatus.Free)
        };
        public static List<User> users = new List<User>
        {
            new User(1, "login1", "pass1", Role.Staff),
            new User(2, "login2", "pass2", Role.Guest),
            new User(3, "login3", "pass3", Role.Guest)
        };
        public static List<Person> person = new List<Person>
        {
            new Person(1, 2, "kulosis", 22, "kulos@gmail.com", "Moscow"),
            new Person(2, 3, "saber", 21, "saber@gmail.com", "Hanoi"),
            new Person(3, 1, "paladin", 20, "paladin@gmail.com", "NewYork")
        };

        public static List<Request> request = new List<Request>
        {
            new Request(1, 2, 1, 15000, DateTime.Parse("01-03-2023"), DateTime.Parse("02-03-2023"), RequestStatus.None),
            new Request(2, 3, 2, 20000, DateTime.Parse("01-02-2023"), DateTime.Parse("04-02-2023"), RequestStatus.None),
            new Request(3, 1, 3, 30000, DateTime.Parse("05-02-2023"), DateTime.Parse("07-02-2023"), RequestStatus.None)
        };
    }
}
