using System.Collections.Generic;
using BL;
using Error;
using Models;

namespace GUIManager
{
    public class GUIGuest
    {
        private GuestManager guestManager;
        private UserManager userManager;
        public GUIGuest(GuestManager guestManager, UserManager userManager)
        {
            this.guestManager = guestManager;
            this.userManager = userManager;
        }
        
    }
}