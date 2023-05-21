using BL;
using Models;
using UITech.Utility;

namespace UI
{
    internal class UIRoom
    {
        private RoomManager roomManager;
        
        public UIRoom(RoomManager roomManager)
        {
            this.roomManager = roomManager;
        }
        public void printRoomList()
        {
            List<Room> roomList = this.roomManager.getRoomList();
            foreach (Room room in roomList)
            {
                Console.WriteLine("ID = " + room.Id_room.ToString() + ", Room Number : " + room.Number.ToString() + ", Status : " + room.Status.ToString());
            }
        }
        public void updateRoom()
        {
            MyLogger.GetInstance().Info("Updating room."); //log
            Console.Write("\nUpdate Room: ");
            int num = Convert.ToInt32(Console.ReadLine());
            try
            {
                int id_room = this.roomManager.getIdRoom(num);
                if (id_room > 1)
                    this.roomManager.updateRoom(id_room);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void addRoom()
        {
            MyLogger.GetInstance().Info("Adding room."); //log
            Console.Write("Input Room Number: ");
            int room_num = Convert.ToInt32(Console.ReadLine());

            RoomStatus status = RoomStatus.None;
            try
            {
                this.roomManager.addRoom(new Room(room_num, status));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeRoom()
        {
            MyLogger.GetInstance().Info("Removing room."); //log
            Console.Write("Input Room Number: ");
            int room_num = Convert.ToInt32(Console.ReadLine());
            try
            {
                int id_room = roomManager.getIdRoom(room_num);
                if (id_room > 1)
                {
                    this.roomManager.removeRoom(id_room);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
