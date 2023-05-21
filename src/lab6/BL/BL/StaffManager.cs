using Models;
using Error;
using InterfaceDB;

namespace BL
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
            Person? staff = this.istaff.getStaff(id);
            if (staff != null)
                return staff;
            else
            {
                throw new PersonNotFoundException();
            }
        }
        public void updateStaff(int id, string name, int age, string email, string address)
        {
            Person? guest = this.istaff.getStaff(id);
            if (guest == null)
                throw new UpdatePersonErrorException();
            this.istaff.updateStaff(id, name, age, email, address);
        }
        public void removeStaff(int id)
        {
            if (id < 1)
                throw new PersonNotFoundException();
            if (this.istaff.getStaff(id) != null)
                this.istaff.removeStaff(id);
            else
                throw new PersonNotFoundException();
        }
        public List<Person> getStaffList()
        {
            return this.istaff.getStaffList();
        }
        public int getIdByUser(int id_login)
        {
            return this.istaff.getIdByUser(id_login);
        }
    }
}
