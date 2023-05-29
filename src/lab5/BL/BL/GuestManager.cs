using Models;
using Error;
using InterfaceDB;

namespace BL
{
    public class GuestManager
    {
        private IGuestRepository iguest;
        private readonly IUserRepository user;
        public IGuestRepository Iguest { get { return iguest; } set { iguest = value; } }
        public GuestManager(IGuestRepository iguest, IUserRepository user)
        {
            this.iguest = iguest;
            this.user = user;
        }

        public void addGuest(Person person)
        {
            if (person.Name.Length < 1 || person.Age < 15 || person.Email.Length < 1)
                throw new AddPersonErrorException();
            else
                this.iguest.addGuest(person);
        }
        public Person getGuest(int id)
        {
            if (id < 1)
                throw new PersonNotFoundException();
            Person? guest = this.iguest.getGuest(id);
            if (guest != null)
                return guest;
            else
            {
                throw new PersonNotFoundException();
            }       
        }
        public void updateGuest(int id, string name, int age, string email, string address)
        {
            Person? guest = this.iguest.getGuest(id);
            if (guest == null)
                throw new UpdatePersonErrorException();
            this.iguest.updateGuest(id, name, age, email, address);
        }
        public void removeGuest(int id) 
        {
            if (id < 1)
                throw new PersonNotFoundException();
            if (this.iguest.getGuest(id) != null)
                this.iguest.removeGuest(id);
            else
                throw new PersonNotFoundException();
        }
        public List<Person> getGuestList()
        {
            return this.iguest.getGuestList();
        }
        public int getIdByUser(int id_login)
        {
            return this.iguest.getIdByUser(id_login);
        }
    }
}
