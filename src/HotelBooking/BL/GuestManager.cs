using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
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
            Person guest = this.iguest.getGuest(id);
            if (guest.Id != -1)
                return guest;
            else
            {
                throw new PersonNotFoundException();
            }       
        }
        public void updateGuest(int id, string name, int age, string email, string address)
        {
            Person guest = this.iguest.getGuest(id);
            if (guest.Id == -1)
                throw new UpdatePersonErrorException();
            this.iguest.updateGuest(id, name, age, email, address);
        }
        public void removeGuest(int id) 
        {
            if (id < 1)
                throw new PersonNotFoundException();
            if (this.iguest.getGuest(id).Id != -1)
                this.iguest.removeGuest(id);
            else
                throw new PersonNotFoundException();
        }
    }
}
