namespace HotelBooking
{
    public interface IGuestRepository
    {
        void addGuest(Person person);
        Person? getGuest(int id);
        void updateGuest(int id, string name, int age, string email, string address);
        void removeGuest(int id);
    }
}
