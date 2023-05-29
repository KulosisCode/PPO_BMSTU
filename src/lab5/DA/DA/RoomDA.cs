using System.Data;
using Npgsql;
using InterfaceDB;
using Models;
using Error;

namespace DA
{
    public class RoomDA : IRoomRepository
    {
        private string connectQuery;
        private NpgsqlConnection connector;
        public NpgsqlConnection Connector { get => connector; set => connector = value; }

        public RoomDA(ConnectionDA Info)
        {
            this.connectQuery = Info.getConnection();
            this.Connector = new NpgsqlConnection(this.connectQuery);
            if (this.Connector == null)
                throw new DataBaseConnectException();
            this.Connector.Open();
            if (this.Connector.State != ConnectionState.Open)
                throw new DataBaseConnectException();
        }
        public void addRoom(Room room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryAddRoom(room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public Room? getRoom(int id_room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            Room? room = null;
            string sql = queryGetRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                room = new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomStatus)Enum.Parse(typeof(RoomStatus),reader.GetString(2)));
            }
            reader.Close();
            return room;
        }
        public int getIdRoom(int num)
        {
            ConnectionCheck.checkConnection(this.Connector);
            int id = -1;
            string sql = queryGetIdRoom(num);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetInt32(0);
            }
            reader.Close();
            return id;
        }
        public void removeRoom(int id_room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryRemoveRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public void updateRoom(int id_room)
        {
            ConnectionCheck.checkConnection(this.Connector);
            string sql = queryUpdateRoom(id_room);
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            command.ExecuteNonQuery();
        }
        public List<Room> getRoomList()
        {
            ConnectionCheck.checkConnection(this.Connector);
            List<Room> allRoom = new List<Room>();
            string sql = queryGetRoomList();
            NpgsqlCommand command = new NpgsqlCommand(sql, this.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                    allRoom.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), (RoomStatus)Enum.Parse(typeof(RoomStatus), reader.GetString(2))));
            reader.Close();
            return allRoom;
        }
        string queryAddRoom(Room room)
        {
            return "insert into Rooms(number, status) values (" + room.Number.ToString() + ", " 
                + ((int)room.Status).ToString() + ");";
        }
        public string queryGetRoom(int id_room)
        {
            return "select * from Rooms where id_room = " + id_room.ToString() + ";";
        }
        public string queryGetIdRoom(int num)
        {
            return "select id_room from Rooms where number = " + num.ToString() + ";";
        }
        string queryRemoveRoom(int id_room)
        {
            return "delete from Rooms where id_room = " + id_room.ToString() + ";";
        }
        string queryUpdateRoom(int id_room)
        {
            return "update Rooms set status =  CASE  when status = '"+ RoomStatus.Free.ToString() +"' then '" + RoomStatus.Busy.ToString() +
                    "' when status = '"+ RoomStatus.Busy.ToString() + "' then '" + RoomStatus.Free.ToString() + 
                    "' else '" + RoomStatus.Free.ToString() + "' END " +
                    "where id_room = " + id_room.ToString() + ";";
        }
        string queryGetRoomList()
        {
            return "select * from Rooms;";
        }
    }
}
