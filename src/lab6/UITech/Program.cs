using BL;
using DA;
using NLog.Config;
using System.Text;
using System.Configuration;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var conString = ConfigurationManager.ConnectionStrings["PSQL"].ConnectionString;
            //ConnectionDA connection = new ConnectionDA("postgres", "localhost", "my_ppo", "haoasd", 5432);
            ConnectionDA connection = new ConnectionDA(conString);
            RoomDA roomDA = new RoomDA(connection);
            UserDA userDA = new UserDA(connection);
            GuestDA guestDA = new GuestDA(connection);
            StaffDA staffDA = new StaffDA(connection);
            RequestDA requestDA = new RequestDA(connection);
            HistoryDA historyDA = new HistoryDA(connection);

            RoomManager roomManager = new RoomManager(roomDA);
            UserManager userManager = new UserManager(userDA);
            GuestManager guestManager = new GuestManager(guestDA, userDA);
            StaffManager staffManager = new StaffManager(staffDA, userDA);
            RequestManager requestManager = new RequestManager(requestDA, guestDA, roomDA);
            HistoryManager historyManager = new HistoryManager(historyDA, requestDA, staffDA);

            UIRoom uiRoom = new UIRoom(roomManager);
            UIUser uiUser = new UIUser(userManager);
            UIGuest uiGuest = new UIGuest(guestManager, userManager);
            UIStaff uiStaff = new UIStaff(staffManager, userManager);
            UIRequest uiRequest = new UIRequest(requestManager, guestManager, roomManager);
            UIHistory uiHistory = new UIHistory(staffManager, requestManager, historyManager);

            ConsoleApp conApp = new ConsoleApp(uiRoom, uiUser, uiGuest, uiStaff, uiRequest, uiHistory);
            while(true)
            {
                conApp.menu();
            }
        }

    }
}