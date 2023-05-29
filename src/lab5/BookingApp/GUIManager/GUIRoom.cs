using System.Collections.Generic;
using BL;
using Error;
using Models;

namespace GUIManager
{
    public class GUIRoom
    {
        private RoomManager roomManager;
        public GUIRoom(RoomManager roomManager)
        {
            this.roomManager = roomManager;
        }
        public Room getRoom(int id)
        {
            return roomManager.getRoom(id);
        }
        public List<Room> getRoomList()
        {
            return this.roomManager.getRoomList();
        }
    }
}
