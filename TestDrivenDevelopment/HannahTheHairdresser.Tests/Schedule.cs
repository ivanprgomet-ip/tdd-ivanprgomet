using System;
using System.Collections.Generic;
using System.Linq;

namespace HannahTheHairdresser.Tests
{
    public class Schedule
    {
        private Dictionary<DateTime, List<Booking>> scheduleByDay = 
            new Dictionary<DateTime, List<Booking>>();

        public void OpenOn(DateTime dateTime)
        {
            scheduleByDay.Add(dateTime.Date, new List<Booking>());
        }
        public void MakeBooking(string name, DateTime when, TimeSpan duration)
        {
            /// We use a Linq query to find any overlapping bookings. 
            /// If it finds any, we throw the expected exception type, making the test pass.

            var dayBookings = scheduleByDay[when.Date];

            var whenEnd = when.Add(duration);

            var overlap = from booking in dayBookings
                          let bookingEnd = booking.When.Add(booking.Duration)
                          where (when > booking.When && when < bookingEnd) || (whenEnd > booking.When && whenEnd < bookingEnd)
                          select booking;

            if (overlap.Any()) throw new OverlappingBookingException();

            dayBookings.Add(new Booking(name, when, duration));
        }
        public List<Booking> GetBookingsFor(DateTime day)
        {
            return scheduleByDay[day.Date]
                .OrderBy(b=>b.When)
                .ToList();
        }
    }
}