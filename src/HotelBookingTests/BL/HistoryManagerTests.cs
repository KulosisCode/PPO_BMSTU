using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Tests
{
    public class TestHistoryRepo : IHistoryRepository
    {
        private List<History> histoties = new List<History>();
        public TestHistoryRepo(List<History> histoties)
        {
            this.histoties = histoties;
        }
        public void addHistory(History history)
        {
            int N = this.histoties.Count;
            this.histoties.Add(new History(N + 1, history.Id_request, history.Id_staff, history.TimeAdded));
        }
        public History getHistory(int id)
        {
            foreach (History history in this.histoties)
            {
                if (history.Id == id) return history;
            }
            return new History();
        }
        public void removeHistory(int id)
        {
            List<History> newHistory = new List<History>();
            foreach (History history in this.histoties)
            {
                if (history.Id != id)
                    newHistory.Add(history);
            }
            this.histoties = newHistory;
        }
    }
    [TestClass()]
    public class HistoryManagerTests
    {
        [TestMethod()]
        public void addHistoryTest()
        {
            List<History> histories = new List<History>();
            histories.Add(new History(1, 1, 2, DateTime.Parse("10-03-2023")));
            histories.Add(new History(2, 2, 3, DateTime.Parse("11-03-2023")));

            TestHistoryRepo testHistory = new TestHistoryRepo(histories);
            TestRequestRepo testRequest = new TestRequestRepo(Obj.request);
            TestStaffRepo testStaff = new TestStaffRepo(Obj.person);

            HistoryManager historyManager = new HistoryManager(testHistory, testRequest, testStaff);

            historyManager.addHistory(new History(3, 1, DateTime.Parse("09-03-2023")));

            History history = historyManager.getHistory(3);
            Assert.AreEqual(history.Id, 3);
        }

        [TestMethod()]
        public void getHistoryTest()
        {
            List<History> histories = new List<History>();
            histories.Add(new History(1, 1, 2, DateTime.Parse("10-03-2023")));
            histories.Add(new History(2, 2, 3, DateTime.Parse("11-03-2023")));

            TestHistoryRepo testHistory = new TestHistoryRepo(histories);
            TestRequestRepo testRequest = new TestRequestRepo(Obj.request);
            TestStaffRepo testStaff = new TestStaffRepo(Obj.person);

            HistoryManager historyManager = new HistoryManager(testHistory, testRequest, testStaff);

            History history = historyManager.getHistory(1);
            Assert.AreEqual(history.Id_staff, 2);
        }

        [TestMethod()]
        public void removeHistoryTest()
        {
            List<History> histories = new List<History>();
            histories.Add(new History(1, 1, 2, DateTime.Parse("10-03-2023")));
            histories.Add(new History(2, 2, 3, DateTime.Parse("11-03-2023")));

            TestHistoryRepo testHistory = new TestHistoryRepo(histories);
            TestRequestRepo testRequest = new TestRequestRepo(Obj.request);
            TestStaffRepo testStaff = new TestStaffRepo(Obj.person);

            HistoryManager historyManager = new HistoryManager(testHistory, testRequest, testStaff);

            historyManager.removeHistory(1);

            History history = testHistory.getHistory(1);
            Assert.AreEqual(history.Id, -1);
        }
    }
}