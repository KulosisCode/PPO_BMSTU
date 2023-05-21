using System.Data;
using Npgsql;
using InterfaceDB;
using Models;
using Error;

namespace DA
{
    public class GuestDA : IGuestRepository
    {
        // chung
        private string connectQuery;
        private NpgsqlConnection? connector;
        public NpgsqlConnection? Connector { get => connector; set => connector = value; }

        public GuestDA(ConnectionDA Info) 
        {
            this.connectQuery = Info.getConnection();
            this.Connector = new NpgsqlConnection(this.connectQuery);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        //method
        public void addGuest(Person person)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryAddGuest(person);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }

        public Person? getGuest(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetGuest(id);
            Person? guest = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                guest = new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            }
            reader.Close();
            return guest;
        }

        public void updateGuest(int id, string name, int age, string email, string address)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryUpdateGuest(id, name, age, email, address);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void removeGuest(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryRemoveGuest(id);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public List<Person> getGuestList()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<Person> allGuest = new List<Person>();
            string sql = queryGetGuestList();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    allGuest.Add(new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5)));
            reader.Close();
            return allGuest;
        }
        public int getIdByUser(int id_login)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetIdGuest(id_login);
            int id = -1;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32(0);
            }
            reader.Close();
            return id;
        }
        //query sql
        public string queryAddGuest(Person person)
        {
            return "insert into Guests(id_login, name, age, email, address) values ( "+ person.Id_login.ToString()+ ", '" + person.Name +
                    "', " + person.Age.ToString() + ", '" + person.Email + "', '" + person.Address + "')";
        }
        public string queryGetGuest(int id)
        {
            return "select * from Guests where id = " + id.ToString() + ";";
        }
        public string queryUpdateGuest(int id, string name,  int age, string email, string address)
        {
            return "update Guests set name = '" + name + "' , age = " + age.ToString() + " , email = '" + email + "', address = '" + address + "' " +
                    " where id = " + id.ToString() + ";";
        }
        public string queryRemoveGuest(int id)
        {
            return "delete from Guests where id = " + id.ToString() + ";";
        }
        public string queryGetGuestList()
        {
            return "select * from Guests;";
        }
        public string queryGetIdGuest(int id_login)
        {
            return "select id from Guests where id_login = " + id_login.ToString() + ";";
        }
    }
}
