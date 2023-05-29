using System.Collections.Generic;
using BL;
using Error;
using Models;

namespace GUIManager
{
    public class GUIStaff
    {
        private StaffManager staffManager;
        private UserManager userManager;

        public GUIStaff(StaffManager staffManager, UserManager userManager)
        {
            this.staffManager = staffManager;
            this.userManager = userManager;
        }
    }
}
