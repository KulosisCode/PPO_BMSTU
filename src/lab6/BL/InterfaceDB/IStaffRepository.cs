using Models;
namespace InterfaceDB
{
    public interface IStaffRepository
    {
        void addStaff(Person staff);
        Person? getStaff(int id);
        void updateStaff(int id, string name, int age, string email, string address);
        void removeStaff(int id);
        List<Person> getStaffList();
        int getIdByUser(int id_login);
    }
}
