using Models;

namespace InterfaceDB
{
    public interface IRequestRepository
    {
        void addRequest(Request request);
        Request? getRequest(int id);
        void updateRequest(int id, RequestStatus status);
        void removeRequest(int id);
        List<Request> getRequestList();
        List<Request> getRequestByLogin(int id_guest);
    }
}
