using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public enum RequestStatus
    {
        None,
        Approve,
        Deny
    };
    public class Request
    {
        private int id;
        private int id_guest;
        private int id_room;
        private int price;
        private DateTime timeIn;
        private DateTime timeOut;
        private RequestStatus status;
        public int Id { get { return id; } set { id = value; } }
        public int Id_guest { get { return id_guest; } set { id_guest = value; } }
        public int Id_room { get { return id_room; } set { id_room = value; } }
        public int Price { get { return price; } set { price = value; } }
        public DateTime TimeIn { get {  return timeIn; } set {  timeIn = value; } }
        public DateTime TimeOut { get {  return timeOut; } set { timeOut = value; } }
        public RequestStatus Status { get { return status; } set { status = value; } }
        public Request() 
        {
            this.id = -1;
            this.id_guest = -1;
            this.id_room = -1;
            this.price = -1;
            this.timeIn = DateTime.Parse("01-01-0001");
            this.timeOut = DateTime.Parse("01-01-0001");
            this.status = RequestStatus.None;
        }
        public Request(int id, int id_guest, int id_room, int price, DateTime timeIn, DateTime timeOut, RequestStatus status)
        {
            this.id = id;
            this.id_guest = id_guest;
            this.id_room = id_room;
            this.price = price;
            this.timeIn = timeIn;
            this.timeOut = timeOut;
            this.status = status;
        }
        public Request(int id_guest, int id_room, int price, DateTime timeIn, DateTime timeOut, RequestStatus status)
        {
            this.id_guest = id_guest;
            this.id_room = id_room;
            this.price = price;
            this.timeIn = timeIn;
            this.timeOut = timeOut;
            this.status = status;
        }
    }
}
