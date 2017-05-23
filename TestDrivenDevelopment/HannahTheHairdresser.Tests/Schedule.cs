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
            if (OverlapsExisting(when, duration))
                throw new OverlappingBookingException(SuggestTimeFor(when, duration));

            scheduleByDay[when.Date].Add(new Booking(name, when, duration));
        }
        private bool OverlapsExisting(DateTime when, TimeSpan duration)
        {
            var dayBookings = scheduleByDay[when.Date];

            var whenEnd = when.Add(duration);

            var overlap = from booking in dayBookings
                          let bookingEnd = booking.When.Add(booking.Duration)
                          where (when > booking.When && when < bookingEnd) || (whenEnd > booking.When && whenEnd < bookingEnd)
                          select booking;

            if (overlap.Any())
                return true;
            else
                return false;
        }
        private DateTime? SuggestTimeFor(DateTime tried, TimeSpan duration)
        {
            var after = scheduleByDay[tried.Date].Where(b => b.When >= tried);
            foreach (var booking in after)
            {
                var finishedBy = booking.When.Add(booking.Duration);
                if (!OverlapsExisting(finishedBy, duration))
                    return finishedBy;
            }
            return null;
        }


        public List<Booking> GetBookingsFor(DateTime day)
        {
            return scheduleByDay[day.Date]
                .OrderBy(b => b.When)
                .ToList();
        }
    }
}