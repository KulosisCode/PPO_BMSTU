using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
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
            History history = this.ihistory.getHistory(id);
            if (history.Id == -1)
                throw new AddHistoryErrorException();
            else
                return history;
        }

        public void removeHistory(int id)
        {
            if (this.ihistory.getHistory(id).Id == -1)
                throw new HistoryNotFoundException();
            else
                this.ihistory.removeHistory(id);
        }

    }
}
