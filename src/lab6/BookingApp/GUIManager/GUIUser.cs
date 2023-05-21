using System.Collections.Generic;
using BL;
using Error;
using Models;

namespace GUIManager
{
    public class GUIUser
    {
        private UserManager userManager;
        public GUIUser(UserManager userManager)
        {
            this.userManager = userManager;
        }
       
        public Role tryAuthorize(string login, string password)
        {
            Role role = Role.None;
            if (this.userManager.userExists(login))
            {
                int id = this.userManager.getIdUser(login);
                User user = this.userManager.getUser(id);
                if (user.Password == password)
                    role = user.ARole;
                else
                    throw new PasswordWrongException();
            }
            else
                throw new LoginNotFoundException();
            return role;
        }
        public int getIdUser(string login)
        {
            return this.userManager.getIdUser(login);
        }
    }
}
