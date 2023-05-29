using System.Data;
using Npgsql;
using InterfaceDB;
using Models;
using Error;

namespace DA
{
    public class UserDA : IUserRepository
    {
        private string connectQuery;
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public UserDA(ConnectionDA Info)
        {
            this.connectQuery = Info.getConnection();
            this.Connector = new NpgsqlConnection(this.connectQuery);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public int getIdUser(string login)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetIdUser(login);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            int id = -1;
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32(0);
            }
            reader.Close();
            return id;
        }
        public User? getUser(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetUser(id);
            User? user = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (Role)Enum.Parse(typeof(Role),reader.GetString(3)));
            }
            reader.Close();
            return user;
        }
        public List<User> getUserList()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<User> allUser = new List<User>();
            string sql = this.queryGetUserList();
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    allUser.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (Role)Enum.Parse(typeof(Role), reader.GetString(3))));
            reader.Close();
            return allUser;
        }
        public void addUser(string login, string password, Role role)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryAddUser(login, password, role);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void removeUser(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryRemoveUser(id);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void updateUser(int id, string password) 
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryUpdateUser(id, password);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public string queryGetIdUser(string login)
        {
            return "select id from Users where login = '" + login + "';";
        }
        public string queryGetUser(int id)
        {
            return "select * from Users where id = " + id.ToString() + ";";
        }
        public string queryGetUserList()
        {
            return "select * from Users;";
        }
        public string queryAddUser(string login, string password, Role role)
        {
            return "insert into Users(login, password, role) values ('" + login + "', '" + password + "', '" + role.ToString() + "');";
        }
        public string queryRemoveUser(int id)
        {
            return "delete from Users where id = " + id.ToString() + ";";
        }
        public string queryUpdateUser(int id, string password)
        {
            return "update Users set password = '" + password +
                    "' where id = " + id.ToString() + ";";
        }
    }
}
