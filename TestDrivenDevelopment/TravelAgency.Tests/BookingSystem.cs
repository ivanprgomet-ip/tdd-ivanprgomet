using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.ConsoleGui;

namespace TravelAgency.Tests
{
    public class BookingSystem
    {
        private ITourSchedule tourScheduleStub;
        public List<Booking> Bookings { get; set; }

        public BookingSystem(ITourSchedule tourScheduleStub)
        {
            this.tourScheduleStub = tourScheduleStub;
            Bookings = new List<Booking>();
        }

        public void CreateBooking(string name, DateTime when, Passenger passenger)
        {
            Tour tour = tourScheduleStub.GetToursFor(when).FirstOrDefault(x => x.Name == name);

            if (tour == null)
                throw new TourDoesntExistException();

            if (tour.AvailableSeats < 1)
                throw new InvalidSeatAmountException($"no available seats left for this tour!");

            Bookings.Add(
                new Booking()
                {
                    Tour = tour,
                    Passenger = passenger,
                });

            tour.AvailableSeats -= 1; // update available seats
        }

        public List<Booking> GetBookingFor(Passenger passenger)
        {
            var bookings = Bookings.Where(b => b.Passenger == passenger).ToList();

            return bookings.Count == 0 ? null : bookings;
        }
    }
}