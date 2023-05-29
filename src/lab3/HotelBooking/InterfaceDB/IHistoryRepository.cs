namespace HotelBooking
{
    public interface IHistoryRepository
    {
        void addHistory (History history);
        History? getHistory(int id);
        void removeHistory(int id);
    }
}
