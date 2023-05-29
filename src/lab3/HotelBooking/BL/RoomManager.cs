using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{

    public class RoomManager
    {
        private IRoomRepository iroom;
        public IRoomRepository Iroom { get { return iroom; } set { iroom = value; } }
        public RoomManager(IRoomRepository iroom) 
        {
            this.iroom = iroom;
        }

        public void addRoom(Room room) 
        {
            List<Room> allRoom = this.iroom.getRoomList();
            foreach (Room elem in allRoom)
                if (elem.Number == room.Number)
                    throw new RoomExistsException();
            this.iroom.addRoom(room);
        }

        public Room getRoom(int id_room)
        {
            Room? room = this.iroom.getRoom(id_room);
            if (room == null)
            {
                throw new RoomNotFoundException();
            }
            else
                return room;
        }

        public void updateRoom(int id_room)
        {
            Room? room = this.iroom.getRoom(id_room);
            if (room == null)
            {
                throw new RoomNotFoundException();
            }
            else
                this.iroom.updateRoom(id_room);
        }

        public void removeRoom(int id_room) 
        {
            Room? room = this.iroom.getRoom(id_room);
            if (room == null)
                throw new RoomNotFoundException();
            else
            {
                this.iroom.removeRoom(id_room);
                room = this.iroom.getRoom(id_room);
                if (room != null)
                    throw new RemoveRoomErrorException();//????
            }
        }

        public List<Room> getRoomList()
        {
            return this.iroom.getRoomList();
        }
    }
}
