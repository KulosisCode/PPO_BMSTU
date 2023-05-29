using System.Data;
using Npgsql;

namespace HotelBooking
{
    public class StaffDA
    {
        // chung
        private string connectQuery;
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public StaffDA(ConnectionDA Info)
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
        public void addStaff(Person person)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryAddStaff(person);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }

        public Person? getStaff(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetStaff(id);
            Person? Staff = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Staff = new Person(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
            }
            reader.Close();
            return Staff;
        }

        public void updateStaff(int id, string name, int age, string email, string address)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryUpdateStaff(id, name, age, email, address);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void removeStaff(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryRemoveStaff(id);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        //query sql
        public string queryAddStaff(Person person)
        {
            return "insert into Staffs(id_login, name, age, email, address) values ( " + person.Id_login.ToString() + ", '" + person.Name +
                    "', " + person.Age.ToString() + ", '" + person.Email + "', '" + person.Address + "')";
        }
        public string queryGetStaff(int id)
        {
            return "select * from Staffs where id = " + id.ToString() + ";";
        }
        public string queryUpdateStaff(int id, string name, int age, string email, string address)
        {
            return "update Staffs set name = '" + name + "' , age = " + age.ToString() + " , email = '" + email + "', address = '" + address + "' " +
                    " where id = " + id.ToString() + ";";
        }
        public string queryRemoveStaff(int id)
        {
            return "delete from Staffs where id = " + id.ToString() + ";";
        }
    }
}
