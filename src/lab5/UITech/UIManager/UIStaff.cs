using BL;
using Models;


namespace UI
{
    internal class UIStaff
    {
        private StaffManager staffManager;
        private UserManager userManager;

        public UIStaff(StaffManager staffManager, UserManager userManager)
        {
            this.staffManager = staffManager;
            this.userManager = userManager;
        }
        public void addStaff()
        {
            Console.Write("Input Name: ");
            string name = Console.ReadLine();

            Console.Write("Input Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Input Login: ");
            string login = Console.ReadLine();

            Console.Write("Input Password: ");
            string password = Console.ReadLine();
            try
            {
                this.userManager.addUser(login, password, Role.Staff);
                int id = this.userManager.getIdUser(login);
                this.staffManager.addStaff(new Person(id, name, age, email, address));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void getStaffList()
        {
            List<Person> staffList = this.staffManager.getStaffList();
            foreach (Person person in staffList)
            {
                Console.WriteLine("Name :" + person.Name + " Age: " + person.Age + " Email: " + person.Email + " Address: " + person.Address + " Id_Login: " + person.Id_login);
            }
        }
        public void getInfoStaff(int id)
        {
            try
            {
                Person staff = this.staffManager.getStaff(id);
                if (staff != null)
                    Console.WriteLine("Name :" + staff.Name + " Age: " + staff.Age + " Email: " + staff.Email + " Address: " + staff.Address + " Id_Login: " + staff.Id_login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void changeInfoStaff(int id)
        {
            Console.Write("Input Name: ");
            string name = Console.ReadLine();

            Console.Write("Input Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();
            try
            {
                this.staffManager.updateStaff(id, name, age, email, address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public int getIdByUser(int id_login)
        {
            return this.staffManager.getIdByUser(id_login);
        }
    }
}
