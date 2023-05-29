using BL;
using Models;
using System;

namespace UI
{
    internal class UIGuest
    {
        private GuestManager guestManager;
        private UserManager userManager;

        public UIGuest(GuestManager guestManager, UserManager userManager)
        {
            this.guestManager = guestManager;
            this.userManager = userManager;
        }
        public void addGuest()
        {
            Console.Write("Input Login: ");
            string login = Console.ReadLine();

            Console.Write("Input Password: ");
            string password = Console.ReadLine();
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
                this.userManager.addUser(login, password, Role.Guest);
                int id = this.userManager.getIdUser(login);
                this.guestManager.addGuest(new Person(id, name, age, email, address));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }
        public void getGuestList()
        {
            List<Person> guestList = this.guestManager.getGuestList();
            foreach (Person person in guestList)
            {
                Console.WriteLine("Name :" + person.Name + " Age: " + person.Age + " Email: " + person.Email + " Address: " + person.Address + " Id_Login: " + person.Id_login);
            }
        }
        public void getInfoGuest(int id)
        {
            try
            {
                Person guest = this.guestManager.getGuest(id);
                if (guest != null)
                    Console.WriteLine("Name :" + guest.Name + " Age: " + guest.Age + " Email: " + guest.Email + " Address: " + guest.Address + " Id_Login: " + guest.Id_login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void changeInfoGuest(int id)
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
                this.guestManager.updateGuest(id, name, age, email,address);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public int getIdByUser(int id_login)
        {
                return this.guestManager.getIdByUser(id_login);
        }
    }
}
