using System.Data;
using Npgsql;
using InterfaceDB;
using Models;
using Error;

namespace DA
{
    public class HistoryDA : IHistoryRepository
    {
        private string connectQuery;
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }
        public HistoryDA(ConnectionDA Info)
        {
            this.connectQuery = Info.getConnection();
            this.Connector = new NpgsqlConnection(this.connectQuery);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }

        public void addHistory(History History)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryAddHistory(History);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }

        public History? getHistory(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetHistory(id);
            History? History = null;
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                History = new History(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2),DateTime.Parse(reader.GetDateTime(3).ToString("yyyy-MM-dd")));
            }
            reader.Close();
            return History;
        }
        public void removeHistory(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryRemoveHistory(id);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public List<History> getHistoryList()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<History> allHistory = new List<History>();
            string sql = queryGetHistoryList();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    allHistory.Add(new History(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), DateTime.Parse(reader.GetDateTime(3).ToString("yyyy-MM-dd"))));
            reader.Close();
            return allHistory;
        }
        //query sql
        public string queryAddHistory(History history)
        {
            return "insert into Histories(id_request, id_staff, timeAdded) values (" + history.Id_request.ToString() +
                    "," + history.Id_staff.ToString() + ", '" + history.TimeAdded.ToString() + "' );";
        }
        public string queryGetHistory(int id)
        {
            return "select * from Histories where id = " + id.ToString() + ";";
        }
        public string queryRemoveHistory(int id)
        {
            return "delete from Histories where id = " + id.ToString() + ";";
        }
        public string queryGetHistoryList()
        {
            return "select * from Histories;";
        }
    }
}
