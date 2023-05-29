using BL;
using Models;
using System;

namespace UI
{
    internal class UIRequest
    {
        private RequestManager requestManager;
        private GuestManager guestManager;
        private RoomManager roomManager;
        
        public UIRequest(RequestManager requestManager, GuestManager guestManager, RoomManager roomManager)
        {
            this.requestManager = requestManager;
            this.guestManager = guestManager;
            this.roomManager = roomManager;
        }
        public void getRequestList()
        {
            try
            {
                List<Request> requestList = this.requestManager.getRequestList();
                foreach (Request request in requestList)
                {
                    Console.WriteLine("ID: " + request.Id + " ID_Guest: " + request.Id_guest+ " ID_Room: " + request.Id_room + " Price: "
                                    + request.Price + " TimeIn: " + request.TimeIn + " TimeOut: " + request.TimeOut + " Status: " + request.Status.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void addRequest(int id_login)
        {
            Console.Write("Input Room Number: ");
            int room_num = Convert.ToInt32(Console.ReadLine());
            int id_room = roomManager.getIdRoom(room_num);

            int id_guest = guestManager.getIdByUser(id_login);

            Console.Write("Input Price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            DateTime now = DateTime.Now;
            RequestStatus status = RequestStatus.None;
            try
            {
                this.requestManager.addRequest(new Request(id_guest, id_room, price, now, now, status));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void viewMyRequest(int id_guest)
        {
            try
            {
                List<Request> myRequests = this.requestManager.getRequestByLogin(id_guest);
                foreach (Request request in myRequests)
                {
                    Console.WriteLine("ID: " + request.Id + " ID_Guest: " + request.Id_guest + " ID_Room: " + request.Id_room + " Price: "
                                    + request.Price + " TimeIn: " + request.TimeIn + " TimeOut: " + request.TimeOut + " Status: " + request.Status.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void removeRequest()
        {
            Console.Write("Input Id_request: ");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                this.requestManager.removeRequest(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void approveRequest()
        {
            Console.Write("\nInput Id_Request:");
            int id_request = Convert.ToInt32(Console.ReadLine());
            try
            {
                Request exRequest = this.requestManager.getRequest(id_request);
                if (exRequest != null)
                {
                    Console.Write("\n0.Exit\n1.Approve\n2.Deny\n>>Choose:");
                    int choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 0:
                            break;
                        case 1:
                            this.requestManager.updateRequest(id_request, RequestStatus.Approve);
                            break;
                        case 2:
                            this.requestManager.updateRequest(id_request, RequestStatus.Deny);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
