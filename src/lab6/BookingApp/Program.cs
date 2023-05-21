using BL;
using BookingApp.WinApp;
using DA;
using GUIManager;

using System.Text;
using System.Windows.Forms;

namespace BookingApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ConnectionDA connection = new ConnectionDA("postgres", "localhost", "my_ppo", "haoasd", 5432);
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

            GUIRoom guiRoom = new GUIRoom(roomManager);
            GUIUser guiUser = new GUIUser(userManager);
            GUIGuest guiGuest = new GUIGuest(guestManager, userManager);
            GUIStaff guiStaff = new GUIStaff(staffManager, userManager);
            GUIRequest guiRequest = new GUIRequest(requestManager, guestManager, roomManager);
            GUIHistory guiHistory = new GUIHistory(staffManager, requestManager, historyManager);

            ApplicationConfiguration.Initialize();
            Application.Run(new login(guiUser, guiRoom, guiGuest, guiStaff, guiRequest, guiHistory));
        }
    }
}