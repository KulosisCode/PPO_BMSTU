using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Tests
{
    public class TestRequestRepo : IRequestRepository
    {
        private List<Request> requests;
        public TestRequestRepo(List<Request> requests) 
        {
            this.requests = requests;
        }
        public void addRequest(Request request)
        {
            int N = this.requests.Count;
            this.requests.Add(new Request(N + 1, request.Id_guest, request.Id_room, request.Price, request.TimeIn, request.TimeOut, request.Status));
        }
        public Request? getRequest(int id)
        {
            foreach (Request request in requests)
            {
                if (request.Id == id)
                    return request;
            }
            return null;
        }
        public void updateRequest(int id, RequestStatus status)
        {
            foreach (Request request in requests)
            {
                if (request.Id == id)
                    request.Status = status;
            }
        }
        public void removeRequest(int id)
        {
            List<Request> newRequests = new List<Request>();
            foreach (Request request in requests)
            {
                if (request.Id != id)
                    newRequests.Add(request);
            }
            this.requests = newRequests;
        }
    }
    [TestClass()]
    public class RequestManagerTests
    {
        [TestMethod()]
        public void addRequestTest()
        {
            List<Request> requests = new List<Request>();
            requests.Add(new Request(1, 2, 1, 15000, DateTime.Parse("01-03-2023"), DateTime.Parse("02-03-2023"), RequestStatus.None));
            requests.Add(new Request(2, 3, 2, 20000, DateTime.Parse("01-02-2023"), DateTime.Parse("04-02-2023"), RequestStatus.None));

            TestRequestRepo testRequest = new TestRequestRepo(requests);
            TestGuestRepo testGuest = new TestGuestRepo(Obj.person);
            TestRoomRepo testRoom = new TestRoomRepo(Obj.rooms);
            RequestManager requestManager = new RequestManager(testRequest, testGuest, testRoom);

            requestManager.addRequest(new Request(1, 3, 25000, DateTime.Parse("05-02-2023"), DateTime.Parse("07-02-2023"), RequestStatus.None));

            Request? request = testRequest.getRequest(3);
            Assert.AreEqual(request.Id, 3);
            Assert.AreEqual(request.Id_guest, 1);
        }

        [TestMethod()]
        public void getRequestTest()
        {
            List<Request> requests = new List<Request>();
            requests.Add(new Request(1, 2, 1, 15000, DateTime.Parse("01-03-2023"), DateTime.Parse("02-03-2023"), RequestStatus.None));
            requests.Add(new Request(2, 3, 2, 20000, DateTime.Parse("01-02-2023"), DateTime.Parse("04-02-2023"), RequestStatus.None));

            TestRequestRepo testRequest = new TestRequestRepo(requests);
            TestGuestRepo testGuest = new TestGuestRepo(Obj.person);
            TestRoomRepo testRoom = new TestRoomRepo(Obj.rooms);
            RequestManager requestManager = new RequestManager(testRequest, testGuest, testRoom);

            Request request = requestManager.getRequest(1);
            Assert.AreEqual(request.Price, 15000);
        }

        [TestMethod()]
        public void updateRequestTest()
        {
            List<Request> requests = new List<Request>();
            requests.Add(new Request(1, 2, 1, 15000, DateTime.Parse("01-03-2023"), DateTime.Parse("02-03-2023"), RequestStatus.None));
            requests.Add(new Request(2, 3, 2, 20000, DateTime.Parse("01-02-2023"), DateTime.Parse("04-02-2023"), RequestStatus.None));

            TestRequestRepo testRequest = new TestRequestRepo(requests);
            TestGuestRepo testGuest = new TestGuestRepo(Obj.person);
            TestRoomRepo testRoom = new TestRoomRepo(Obj.rooms);
            RequestManager requestManager = new RequestManager(testRequest, testGuest, testRoom);

            requestManager.updateRequest(1, RequestStatus.Approve);
            Request request = requestManager.getRequest(1);
            Assert.AreEqual(request.Status, RequestStatus.Approve);
        }

        [TestMethod()]
        public void removeRequestTest()
        {
            List<Request> requests = new List<Request>();
            requests.Add(new Request(1, 2, 1, 15000, DateTime.Parse("01-03-2023"), DateTime.Parse("02-03-2023"), RequestStatus.None));
            requests.Add(new Request(2, 3, 2, 20000, DateTime.Parse("01-02-2023"), DateTime.Parse("04-02-2023"), RequestStatus.None));

            TestRequestRepo testRequest = new TestRequestRepo(requests);
            TestGuestRepo testGuest = new TestGuestRepo(Obj.person);
            TestRoomRepo testRoom = new TestRoomRepo(Obj.rooms);
            RequestManager requestManager = new RequestManager(testRequest, testGuest, testRoom);

            requestManager.removeRequest(2);
            Request? request = testRequest.getRequest(2);
            Assert.IsNull(request);
        }
    }
}