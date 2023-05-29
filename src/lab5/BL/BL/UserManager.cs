using Models;
using Error;
using InterfaceDB;

namespace BL
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
            User? user = this.iuser.getUser(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            else
                return user;
        }

        public int getIdUser(string login)
        {
            int id = this.iuser.getIdUser(login);
            if (id == -1)
                throw new UserNotFoundException();
            else
                return id;
        }
        public void removeUser(int id)
        {
            User? user = this.iuser.getUser(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            else
                this.iuser.removeUser(id);
        }
        public void updateUser(int id, string password)
        {
            User? user = this.iuser.getUser(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            else
                this.iuser.updateUser(id, password);
        }
        List<User> getUserList()
        {
            return this.iuser.getUserList();
        }

        public Boolean userExists(string login)
        {
            return this.iuser.getIdUser(login) != -1;
        }
    }
}
