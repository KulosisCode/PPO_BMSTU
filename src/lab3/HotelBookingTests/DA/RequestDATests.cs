using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBookingTests.DA;
using Npgsql;

namespace HotelBooking.Tests
{
    [TestClass()]
    public class RequestDATests
    {
        [TestMethod()]
        public void addRequestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RequestDA requestDA = new RequestDA(info);

            requestDA.addRequest(new Request(2, 1, 3000, DateTime.Parse("2001-03-20"), DateTime.Parse("2001-03-30"), RequestStatus.Deny));

            NpgsqlCommand command = new NpgsqlCommand(requestDA.queryGetRequest(3), requestDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Request request = new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    DateTime.Parse(reader.GetDateTime(4).ToString("yyyy-MM-dd")), DateTime.Parse(reader.GetDateTime(5).ToString("yyyy-MM-dd")), 
                    (RequestStatus)Enum.Parse(typeof(RequestStatus), reader.GetString(6)));
            reader.Close();

            Assert.AreEqual(request.Id, 3);
        }
        [TestMethod()]
        public void getRequestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RequestDA requestDA = new RequestDA(info);

            Request? request = requestDA.getRequest(1);
            Assert.IsNotNull(request);
            Assert.AreEqual(request.Price, 2000);
        }

        [TestMethod()]
        public void updateRequestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RequestDA requestDA = new RequestDA(info);

            requestDA.updateRequest(1, RequestStatus.Approve);

            NpgsqlCommand command = new NpgsqlCommand(requestDA.queryGetRequest(1), requestDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Request request = new Request(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3),
                    DateTime.Parse(reader.GetDateTime(4).ToString("yyyy-MM-dd")), DateTime.Parse(reader.GetDateTime(5).ToString("yyyy-MM-dd")), 
                    (RequestStatus)Enum.Parse(typeof(RequestStatus), reader.GetString(6)));
            reader.Close();

            Assert.IsNotNull(request);
            Assert.AreEqual(request.Status, RequestStatus.Approve);
        }
        [TestMethod()]
        public void removeRequestTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            RequestDA requestDA = new RequestDA(info);

            requestDA.removeRequest(3);
            NpgsqlCommand command = new NpgsqlCommand(requestDA.queryGetRequest(3), requestDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }


    }
}