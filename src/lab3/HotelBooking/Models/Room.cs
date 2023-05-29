using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public enum RoomStatus
    {
        None,
        Busy,
        Free
    };
    public class Room
    {
        private int? id_room;
        private int number;
        private RoomStatus status;
        public int? Id_room { get { return id_room; } set { id_room = value; } }
        public int Number { get { return number; } set { number = value; } }
        public RoomStatus Status { get {  return status; } set { status = value;} }
        public Room() 
        {
            this.id_room = null;
            this.number = -1;
            this.status = RoomStatus.None;
        }
        public Room(int? id_room, int number, RoomStatus status)
        {
            this.id_room = id_room;
            this.number= number;
            this.status = status;
        }
        public Room(int number, RoomStatus status)
        {
            this.id_room = -1;
            this.number = number;
            this.status = status;
        }
    }
}
