using BL;
using Models;


namespace UI
{
    internal class ConsoleApp
    {
        private UIRoom uiRoom;
        private UIUser uiUser;
        private UIGuest uiGuest;
        private UIStaff uiStaff;
        private UIRequest uiRequest;
        private UIHistory uiHistory;
        private Role role;
        private int id_login;

        string MENU_LOGIN = "\n0.Exit Program.\n1.Login To Program.\n2.Register Guest\n>>Cmd:";
        string MENU_GUEST = "\n0.Logout\n1.View All Room\n2.Get My Info\n3.Change My Info\n4.Make Request\n5.View My Request\n" +
                            "6.Delete My Request\n7.ChangePassword\n>>Cmd:";
        string MENU_STAFF = "\n0.Logout\n1.View All Room\n2.Get My Info\n3.Change My Info\n4.Approve Request?\n5.View All Request\n" +
                            "6.View All History\n7.Update Room\n8.ChangePassword\n>>Cmd:";
        string MENU_ADMIN = "\n0.Logout\n1.View All Room\n2.View All Request\n3.View All History\n4.Register For Staff\n5.Add Room\n6.Remove Room\n" +
                            "7.ChangePassword\n>>Cmd:";
        public ConsoleApp(UIRoom uiRoom, UIUser uiUser, UIGuest uiGuest, UIStaff uiStaff, UIRequest uiRequest, UIHistory uiHistory)
        {
            this.uiRoom = uiRoom;
            this.uiUser = uiUser;
            this.uiGuest = uiGuest;
            this.uiStaff = uiStaff;
            this.uiRequest = uiRequest;
            this.uiHistory = uiHistory;
            role = Role.None;
            id_login = -1;
        }
        // xem xets laij ham Console.Readline()
        public void menu()
        {
            if (this.role == Role.None)
            {
                Console.Write(MENU_LOGIN);
                int cmd = Convert.ToInt32(Console.ReadLine());
                switch(cmd)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        try
                        {
                            Role tryrole = this.uiUser.tryLogin();
                            if (tryrole != Role.None)
                            {
                                this.role = tryrole;
                                this.id_login = this.uiUser.getIdUser(this.uiUser.Login);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }

                        break;

                    case 2:
                        this.uiGuest.addGuest();
                        break;
                    default:
                        break;

                }
            }
            else if (this.role == Role.Guest && this.id_login != -1) 
            {
                int id = this.uiGuest.getIdByUser(id_login);
                if (id < 1)
                {
                    Console.WriteLine("This user doesn't has Info!");
                    this.role = Role.None;
                    this.id_login = -1;
                }
                else
                {
                    Console.Write(MENU_GUEST);
                    int cmd = Convert.ToInt32(Console.ReadLine());
                    switch (cmd)
                    {
                        case 0:
                            this.role = Role.None;
                            this.id_login = -1;
                            break;
                        case 1:
                            this.uiRoom.printRoomList();
                            break;
                        case 2:
                            this.uiGuest.getInfoGuest(id);
                            break;
                        case 3:
                            this.uiGuest.changeInfoGuest(id);
                            break;
                        case 4:
                            this.uiRequest.addRequest(id);
                            break;
                        case 5:
                            this.uiRequest.viewMyRequest(id);
                            break;
                        case 6:
                            this.uiRequest.removeRequest();
                            break;
                        case 7:
                            this.uiUser.changePassword(id_login);
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (this.role == Role.Staff && id_login != -1)
            {
                int id_staff = this.uiStaff.getIdByUser(id_login);
                if (id_staff < 1)
                {
                    Console.WriteLine("This user doesn't has Info!");
                    this.role = Role.None;
                    this.id_login = -1;
                }
                else
                {
                    Console.Write(MENU_STAFF);
                    int cmd = Convert.ToInt32(Console.ReadLine());
                    switch (cmd)
                    {
                        case 0:
                            this.role = Role.None;
                            this.id_login = -1;
                            break;
                        case 1:
                            this.uiRoom.printRoomList();
                            break;
                        case 2:
                            this.uiStaff.getInfoStaff(id_staff);
                            break;
                        case 3:
                            this.uiStaff.changeInfoStaff(id_staff);
                            break;
                        case 4:
                            this.uiRequest.approveRequest();
                            break;
                        case 5:
                            this.uiRequest.getRequestList();
                            break;
                        case 6:
                            this.uiHistory.getHistoryList();
                            break;
                        case 7:
                            this.uiRoom.updateRoom();
                            break;
                        case 8:
                            this.uiUser.changePassword(id_login);
                            break;
                        default:
                            break;
                    }
                }
            }
            else if (this.role == Role.Admin && id_login != -1)
            {
                Console.Write(MENU_ADMIN);
                int cmd = Convert.ToInt32(Console.ReadLine());
                switch (cmd)
                {
                    case 0:
                        this.role = Role.None;
                        this.id_login = -1;
                        break;
                    case 1:
                        this.uiRoom.printRoomList();
                        break;
                    case 2:
                        this.uiRequest.getRequestList();
                        break;
                    case 3:
                        this.uiHistory.getHistoryList();
                        break;
                    case 4:
                        this.uiStaff.addStaff();
                        break;
                    case 5:
                        this.uiRoom.addRoom();
                        break;
                    case 6:
                        this.uiRoom.removeRoom();
                        break;
                    case 7:
                        this.uiUser.changePassword(id_login);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
