using Models;
namespace InterfaceDB;

public interface IUserRepository
{
    void addUser(string login, string password, Role role);
    User? getUser(int id);
    int getIdUser(string login);
    void removeUser(int id);
    void updateUser(int id, string password);
    List<User> getUserList();
}
