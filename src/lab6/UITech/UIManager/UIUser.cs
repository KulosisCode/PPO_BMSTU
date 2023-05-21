using BL;
using Error;
using Microsoft.Extensions.Logging;
using Models;
using NLog;
using UITech.Utility;
using System.Configuration;//???

namespace UI
{
    internal class UIUser
    {
        Logger log = LogManager.GetLogger("myAppLoggerRules");
        private UserManager userManager;
        private string? login = string.Empty;
        private string? password = string.Empty;
        public string? Login { get { return login; } set { login = value; } }
        public string? Password { get { return password; } set { password = value; } }

        public UIUser(UserManager userManager)
        { 
            this.userManager = userManager; 
        }
        public Boolean isRegistered(string? login)
        {
            if (login == null)
                return false;
            return this.userManager.userExists(login);
        }
        public Role tryLogin()
        {
            //log 
            MyLogger.GetInstance().Info("Try to login. Login Method");

            Role roleUser = Role.None;
            Console.Write("Введите логин: ");
            this.login = Console.ReadLine();
            if (this.login == null) return Role.None;

            if (isRegistered(login))
            {
                MyLogger.GetInstance().Info("Try password. Login Method"); //log
                Console.Write("Введите пароль: ");
                this.password = Console.ReadLine();
                int id = this.userManager.getIdUser(this.login);
                User user = this.userManager.getUser(id);
                if (user.Password == password)
                {
                    MyLogger.GetInstance().Info("Login Success!"); //log
                    roleUser = user.ARole;
                }
                else
                {
                    MyLogger.GetInstance().Warning("Password Wrong!"); //log
                    throw new PasswordWrongException();
                }
            }
            else
            {
                MyLogger.GetInstance().Warning("Login Wrong!"); //log
                throw new LoginNotFoundException();
            }
            return roleUser;
        }
        public int getIdUser(string? login)
        {
            if (login == null)
                return -1;
            return this.userManager.getIdUser(login);
        }
        public void changePassword(int id_login)
        {
            Console.Write("New Password: ");
            string? newpass = Console.ReadLine();
            if (newpass == null) return;
            try
            {
                this.userManager.updateUser(id_login, newpass);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
