using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public class History
    {
        private int id;
        private int id_request;
        private int id_staff;
        private DateTime timeAdded;
        public int Id { get { return id; } set { id = value; } }
        public int Id_request { get { return id_request; } set { id_request = value; } }
        public int Id_staff { get { return id_staff; } set { id_staff = value; } }
        public DateTime TimeAdded { get {  return timeAdded; } set {  timeAdded = value; } }
        public History() 
        {
            this.id = -1;
            this.id_request = -1;
            this.id_staff = -1;
            this.timeAdded = DateTime.Parse("01-01-0001");
        }
        public History(int id, int id_request, int id_staff, DateTime timeAdded)
        {
            this.id = id;
            this.id_request = id_request;
            this.id_staff = id_staff; 
            this.timeAdded = timeAdded;
        }
        public History(int id_request, int id_staff, DateTime timeAdded)
        {
            this.id = -1;
            this.id_request = id_request;
            this.id_staff = id_staff;
            this.timeAdded = timeAdded;
        }

    }
}
