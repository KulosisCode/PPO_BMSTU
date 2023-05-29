using BL;
using Models;


namespace UI
{
    internal class UIHistory
    {
        StaffManager staffManager;
        RequestManager requestManager;
        HistoryManager historyManager;

        public UIHistory(StaffManager staffManager, RequestManager requestManager, HistoryManager historyManager)
        {
            this.staffManager = staffManager;
            this.requestManager = requestManager;
            this.historyManager = historyManager;
        }

        public void getHistoryList()
        {
            List<History> historyList = this.historyManager.getHistoryList();
            foreach (History history in historyList)
            {
                Console.WriteLine("ID: "+ history.Id +" ID_Request: " + history.Id_request + " ID_Staff: " + history.Id_staff
                                +  " TimeIn: " + history.TimeAdded);
            }
        }

        public void addHistory(int id_login)
        {
            Console.Write("Input Id Request: ");
            int id_request = Convert.ToInt32(Console.ReadLine());

            int id_staff = staffManager.getIdByUser(id_login);

            DateTime now = DateTime.Now;
            try
            {
                this.historyManager.addHistory(new History(id_request, id_staff, now));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
