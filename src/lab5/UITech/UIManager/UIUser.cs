using BL;
using Error;
using Models;


namespace UI
{
    internal class UIUser
    {
        private UserManager userManager;
        private string? login = string.Empty;
        private string? password = string.Empty;
        public string? Login { get { return login; } set { login = value; } }
        public string? Password { get { return password; } set { password = value; } }
        public UIUser(UserManager userManager)
        { this.userManager = userManager; }
        public Boolean isRegistered(string? login)
        {
            if (login == null)
                return false;
            return this.userManager.userExists(login);
        }
        public Role tryLogin()
        {
            Role roleUser = Role.None;
            Console.Write("Введите логин: ");
            this.login = Console.ReadLine();
            if (this.login == null) return Role.None;

            if (isRegistered(login))
            {
                Console.Write("Введите пароль: ");
                this.password = Console.ReadLine();
                int id = this.userManager.getIdUser(this.login);
                User user = this.userManager.getUser(id);
                if (user.Password == password)
                    roleUser = user.ARole;
                else
                    throw new PasswordWrongException();
            }
            else
                throw new LoginNotFoundException();
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
