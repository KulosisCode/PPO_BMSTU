using System;
using System.Data;
using Npgsql;

namespace HotelBooking
{
    public class RequestDA
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

    }
}
