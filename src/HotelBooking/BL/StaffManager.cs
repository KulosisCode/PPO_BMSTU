using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookin
{
    public class StaffManager
    {
        private IStaffRepository istaff;
        private readonly IUserRepository user;
        public IStaffRepository Istaff { get { return istaff; } set { istaff = value; } }
        public StaffManager(IStaffRepository istaff, IUserRepository user)
        {
            this.istaff = istaff;
            this.user = user;
        }

        public void addStaff(Person person)
        {
            if (person.Name.Length < 1 || person.Age < 15 || person.Email.Length < 1)
                throw new AddPersonErrorException();
            else
                this.istaff.addStaff(person);  
        }
        public Person getStaff(int id)
        {
            if (id < 1)
                throw new PersonNotFoundException();
            Person staff = this.istaff.getStaff(id);
            if (staff.Id != -1)
                return staff;
            else
            {
                throw new PersonNotFoundException();
            }
        }
        public void updateStaff(int id, string name, int age, string email, string address)
        {
            Person guest = this.istaff.getStaff(id);
            if (guest.Id == -1)
                throw new UpdatePersonErrorException();
            this.istaff.updateStaff(id, name, age, email, address);
        }
        public void removeStaff(int id)
        {
            if (id < 1)
                throw new PersonNotFoundException();
            if (this.istaff.getStaff(id).Id != -1)
                this.istaff.removeStaff(id);
            else
                throw new PersonNotFoundException();
        }
    }
}
