using Models;
namespace InterfaceDB
{
    public interface IRoomRepository
    {
        void addRoom(Room room);
        Room? getRoom(int id_room);
        int getIdRoom(int num);
        void updateRoom(int id_room);
        void removeRoom(int id_room);
        List<Room> getRoomList();
    }
}
