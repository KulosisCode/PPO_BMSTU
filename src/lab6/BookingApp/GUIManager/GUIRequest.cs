using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIManager
{
    public class GUIRequest
    {
        private RequestManager requestManager;
        private GuestManager guestManager;
        private RoomManager roomManager;

        public GUIRequest(RequestManager requestManager, GuestManager guestManager, RoomManager roomManager)
        {
            this.requestManager = requestManager;
            this.guestManager = guestManager;
            this.roomManager = roomManager;
        }
    }
}
