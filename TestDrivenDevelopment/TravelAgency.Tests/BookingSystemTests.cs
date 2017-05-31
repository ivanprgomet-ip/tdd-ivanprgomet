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
        private BookingSystem sut; // the system under test

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

            tourScheduleStub.Tours = new List<Tour> { tour };

            Passenger passenger = new Passenger
            {
                Firstname = "ivan",
                Lastname = "prgomet"
            };

            // book a passenger for an existing tour
            sut.CreateBooking(tour.Name, tour.When, passenger);
            List<Booking> bookings = sut.GetBookingFor(passenger);

            Assert.AreEqual(1, bookings.Count());
            Assert.AreEqual(tour, bookings[0].Tour);
            //Assert.That(tour.Equals(bookings[0].Tour));
            Assert.AreEqual(passenger, bookings[0].Passenger);
        }

        [Test]
        public void CantBookPassengerOnNonExistentTour()
        {
            Passenger passenger = new Passenger()
            {
                Firstname = "ivan",
                Lastname = "prgomet",
            };

            Assert.Throws<TourDoesntExistException>(()
                => sut.CreateBooking("non Existent Tour Name", new DateTime(9999, 9, 9), passenger));
        }

        [Test]
        public void CantBookPassengerOnMoreSeatsThanAvailableForTour()
        {
            Passenger passengerOne = new Passenger()
            {
                Firstname = "ivan",
                Lastname = "prgomet",
            };

            Passenger passengerTwo = new Passenger()
            {
                Firstname = "ben",
                Lastname = "stiller",
            };


            Tour tour = new Tour()
            {
                Name = "Demo Tour",
                AvailableSeats = 1,
                When = new DateTime(2017, 05, 05)
            };

            tourScheduleStub.Tours = new List<Tour> { tour };

            sut.CreateBooking(tour.Name, tour.When, passengerOne);

            Assert.Throws<InvalidSeatAmountException>(()
                => sut.CreateBooking(tour.Name, tour.When, passengerTwo));
        }
    }

    // handwritten stub. instead of relying on the actual tourschedule implementation.
    public class TourScheduleStub : ITourSchedule
    {
        public List<Tour> Tours { get; set; } = new List<Tour>();

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
