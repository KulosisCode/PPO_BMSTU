using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public enum Role
    {
        None,
        Guest,
        Staff,
        Admin
    }
    public class User
    {
        private int id;
        private string login;
        private string password;
        private Role role;
        public int Id { get { return id; } set { id = value; } }
        public string Login { get { return login; } set { login = value; } }
        public string Password { get { return password; } set { password = value; } }
        public Role ARole { get { return role; } set { role = value; } }

        public User() 
        {
            this.id = -1;
            this.login = string.Empty;
            this.password = string.Empty;
            this.role = Role.None;
        }
        public User(int id, string login, string password, Role role)
        {
            this.id = id;
            this.login = login;
            this.password = password;
            this.role = role;
        }
        public User(string login, string password, Role role)
        {
            this.id = -1;
            this.login = login;
            this.password = password;
            this.role = role;
        }
    }
}
