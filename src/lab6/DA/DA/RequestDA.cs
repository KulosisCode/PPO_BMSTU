using System.Data;
using Npgsql;
using InterfaceDB;
using Models;
using Error;

namespace DA
{
    public class RequestDA : IRequestRepository
    {
        private string connectQuery;
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public RequestDA(ConnectionDA Info)
        {
            this.connectQuery = Info.getConnection();
            this.Connector = new NpgsqlConnection(this.connectQuery);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }

        public void addRequest(Request request)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryAddRequest(request);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }

        public Request? getRequest(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryGetRequest(id);
            Request? Request = null;

            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Request = new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    DateTime.Parse(reader.GetDateTime(4).ToString("yyyy-MM-dd")), DateTime.Parse(reader.GetDateTime(5).ToString("yyyy-MM-dd")), 
                    (RequestStatus)Enum.Parse(typeof(RequestStatus), reader.GetString(6)));
            }
            reader.Close();
            return Request;
        }

        public void updateRequest(int id, RequestStatus status)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryUpdateRequest(id, status);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public void removeRequest(int id)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryRemoveRequest(id);
            NpgsqlCommand cmd = new NpgsqlCommand(sql, this.Connector);
            cmd.ExecuteNonQuery();
        }
        public List<Request> getRequestList()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<Request> allRequest = new List<Request>();
            string sql = queryGetRequestList();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    allRequest.Add(new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    DateTime.Parse(reader.GetDateTime(4).ToString("yyyy-MM-dd")), DateTime.Parse(reader.GetDateTime(5).ToString("yyyy-MM-dd")),
                    (RequestStatus)Enum.Parse(typeof(RequestStatus), reader.GetString(6))));
            reader.Close();
            return allRequest;
        }
        public List<Request> getRequestByLogin(int id_guest)
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<Request> someRequest = new List<Request>();
            string sql = queryGetRequestByLogin(id_guest);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    someRequest.Add(new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    DateTime.Parse(reader.GetDateTime(4).ToString("yyyy-MM-dd")), DateTime.Parse(reader.GetDateTime(5).ToString("yyyy-MM-dd")),
                    (RequestStatus)Enum.Parse(typeof(RequestStatus), reader.GetString(6))));
            reader.Close();
            return someRequest;
        }
        //query sql
        public string queryAddRequest(Request request)
        {
            return "insert into Requests(id_guest, id_room, price, timeIn, timeOut, status)  values (" + request.Id_guest.ToString() +
                    "," + request.Id_room.ToString() + ", " + request.Price.ToString() + ", '" + request.TimeIn.ToString() + "'" +
                    ", '" + request.TimeOut.ToString() + "', '" + request.Status.ToString() + "');";
        }
        public string queryGetRequest(int id)
        {
            return "select * from Requests where id = " + id.ToString() + ";";
        }
        public string queryUpdateRequest(int id, RequestStatus status)
        {
            return "update Requests set status = '" + status.ToString() +
                    "' where id =" + id.ToString() + ";";
        }
        public string queryRemoveRequest(int id)
        {
            return "delete from Requests where id = " + id.ToString() + ";";
        }
        public string queryGetRequestList()
        {
            return "select * from Requests;";
        }
        public string queryGetRequestByLogin(int id_guest)
        {
            return "select * from Requests where id_guest = " + id_guest.ToString() + ";";
        }
    }
}
