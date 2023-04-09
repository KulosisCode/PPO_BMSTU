namespace HotelBooking
{
    public interface IRoomRepository
    {
        void addRoom(Room room);
        Room getRoom(int id_room);
        void updateRoom(int id_room);
        void removeRoom(int id_room);
        List<Room> getRoomList();
    }
}
