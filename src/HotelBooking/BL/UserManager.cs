using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public class UserManager
    {
        private IUserRepository iuser;
        public IUserRepository User { get { return iuser; } set { iuser = value; } }
        public UserManager(IUserRepository iuser)
        {
            this.iuser = iuser;
        }
        public void addUser(string login, string password, Role role)
        {
            List<User> allUser = this.iuser.getUserList();
            foreach (User elem in allUser)
                if (elem.Login == login)
                    throw new AddUserErrorException();
            this.iuser.addUser(login, password, role);
        }
        public User getUser(int id)
        {
            User user = this.iuser.getUser(id);
            if (user.Id == -1)
            {
                throw new UserNotFoundException();
            }
            else
                return user;
        }

        public int getIdUser(string login)
        {
            return this.iuser.getIdUser(login);
        }
        public void removeUser(int id)
        {
            User user = this.iuser.getUser(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            else
                this.iuser.removeUser(id);
        }
        public void updateUser(int id, string password, Role role)
        {
            User user = this.iuser.getUser(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            else
                this.iuser.updateUser(id, password, role);
        }
        List<User> getUserList()
        {
            return this.iuser.getUserList();
        }
    }
}
