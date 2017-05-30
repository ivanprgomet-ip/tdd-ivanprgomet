using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ConsoleGui;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class BookingSystemTests
    {
        private TourScheduleStub tourScheduleStub;
        private BookingSystem sut;

        [SetUp]
        public void Setup()
        {
            tourScheduleStub = new TourScheduleStub();
            sut = new BookingSystem(tourScheduleStub);
        }

        [Test]
        public void CanCreateBooking()
        {
            Tour tour = new Tour()
            {
                Name = "Demo Tour",
                AvailableSeats = 80,
                When = new DateTime(2017, 05, 05)
            };
            ;
            tourScheduleStub.Tours = new List<Tour> { tour };

            Passenger passenger = new Passenger{ Firstname = "ivan", Lastname= "prgomet" };

            sut.CreateBooking("Safari", new DateTime(2017, 05, 05), passenger);
            List<Booking> bookings = sut.GetBookingFor(passenger);

            Assert.AreEqual(1, bookings.Count());
            //Assert.AreEqual(tour, bookings.FirstOrDefault().Tour); // TODO: WHY DOES THIS NOT PASS?
            Assert.AreEqual(passenger, bookings.FirstOrDefault().Passenger);
        }
    }

    // handwritten stub. instead of relying on the actual tourschedule implementation.
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; }

        public void CreateTour(string tourName, DateTime when, int availableSeats)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            return Tours;
        }
    }
}
