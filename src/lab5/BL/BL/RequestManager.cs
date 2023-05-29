using Models;
using Error;
using InterfaceDB;

namespace BL
{
    public class RequestManager
    {
        private IRequestRepository irequest;
        private readonly IGuestRepository iguest;
        private readonly IRoomRepository iroom;
        public IRequestRepository Irequest { get { return irequest; } set { irequest = value; } }

        public RequestManager(IRequestRepository irequest, IGuestRepository iguest, IRoomRepository iroom)
        {
            this.irequest = irequest;
            this.iguest = iguest;
            this.iroom = iroom;
        }

        public void addRequest(Request request)
        {
            if (request.Id_guest == -1 || request.Id_room == -1)
                throw new AddRequestErrorException();
            else
                this.irequest.addRequest(request);
        }
        public Request getRequest(int id)
        {
            if (id < 1) 
                throw new RequestNotFoundException();
            Request? request = this.irequest.getRequest(id);
            if (request != null)
                return request;
            else
                throw new RequestNotFoundException();
        }
        public void updateRequest(int id, RequestStatus status)
        {
            if (id < 1)
                throw new RequestNotFoundException();
            if (this.irequest.getRequest(id) != null)
                this.irequest.updateRequest(id, status);
            else
                throw new RequestNotFoundException();
        }
        public void removeRequest(int id) 
        {
            if (id < 1)
                throw new RequestNotFoundException();
            if (this.irequest.getRequest(id) != null)
                this.irequest.removeRequest(id);
            else
                throw new RequestNotFoundException();
        }
        public List<Request> getRequestList()
        {
            return this.irequest.getRequestList();
        }
        public List<Request> getRequestByLogin(int id_guest)
        {
            if (id_guest < 1)
                throw new RequestNotFoundException();
            return this.irequest.getRequestByLogin(id_guest);
        }
    }
}
