using Models;
using Error;
using InterfaceDB;

namespace BL
{
    public class HistoryManager
    {
        private IHistoryRepository ihistory;
        private readonly IRequestRepository irequest;
        private readonly IStaffRepository istaff;
        public IHistoryRepository History { get { return ihistory; } set { ihistory = value; } }

        public HistoryManager(IHistoryRepository ihistory, IRequestRepository irequest, IStaffRepository istaff)
        {
            this.ihistory = ihistory;
            this.irequest = irequest;
            this.istaff = istaff;
        }

        public void addHistory(History history)
        {
            if (history.Id_request == -1 || history.Id_staff == -1)
                throw new AddHistoryErrorException();
            else
                this.ihistory.addHistory(history);
        }
        public History getHistory(int id)
        {
            if (id < 1)
                throw new AddHistoryErrorException();
            History? history = this.ihistory.getHistory(id);
            if (history == null)
                throw new AddHistoryErrorException();
            else
                return history;
        }

        public void removeHistory(int id)
        {
            if (this.ihistory.getHistory(id) == null)
                throw new HistoryNotFoundException();
            else
                this.ihistory.removeHistory(id);
        }
        public List<History> getHistoryList()
        {
            return this.ihistory.getHistoryList();
        }
    }
}
