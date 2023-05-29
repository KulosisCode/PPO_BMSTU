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
    public class HistoryDATests
    {
        [TestMethod()]
        public void addHistoryTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            HistoryDA historyDA = new HistoryDA(info);

            historyDA.addHistory(new History(2, 1, DateTime.Parse("2023-02-20")));

            NpgsqlCommand command = new NpgsqlCommand(historyDA.queryGetHistory(3), historyDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            History history = new History(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), DateTime.Parse(reader.GetDateTime(3).ToString("yyyy-MM-dd")));
            reader.Close();

            Assert.AreEqual(history.Id, 3);
        }

        [TestMethod()]
        public void getHistoryTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            HistoryDA historyDA = new HistoryDA(info);

            History? history = historyDA.getHistory(2);
            Assert.IsNotNull(history);
            Assert.AreEqual(history.Id_request, 2);
        }

        [TestMethod()]
        public void removeHistoryTest()
        {
            ConnectionDA info = GetConnectInfo.getinfo();
            HistoryDA historyDA = new HistoryDA(info);

            historyDA.removeHistory(3);

            NpgsqlCommand command = new NpgsqlCommand(historyDA.queryGetHistory(3), historyDA.Connector);
            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Assert.AreEqual(reader.HasRows, false);
            reader.Close();
        }
    }
}