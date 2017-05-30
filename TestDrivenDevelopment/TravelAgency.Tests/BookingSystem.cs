using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.ConsoleGui;

namespace TravelAgency.Tests
{
    public class BookingSystem
    {
        private ITourSchedule tourScheduleStub;
        public List<Booking> Bookings { get; set; } // is this in the description?

        public BookingSystem(ITourSchedule tourScheduleStub)
        {
            this.tourScheduleStub = tourScheduleStub;
            Bookings = new List<Booking>();
        }

        public void CreateBooking(string name, DateTime when, Passenger passenger)
        {
            var tour = tourScheduleStub.GetToursFor(when).FirstOrDefault(x => x.Name == name);

            Bookings.Add(
                new Booking()
                {
                    Passenger = passenger,
                    Tour = new Tour()
                    {
                        Name = name,
                        When = when,
                        AvailableSeats = 1,
                    }
                });

        }

        internal List<Booking> GetBookingFor(Passenger passenger)
        {
            var bookings = Bookings.Where(b => b.Passenger == passenger).ToList();

            return bookings;
        }
    }
}