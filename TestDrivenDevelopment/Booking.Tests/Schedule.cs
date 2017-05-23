using System;
using System.Collections.Generic;

namespace Booking.Tests
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
            scheduleByDay[when.Date].Add(new Booking(name, when, duration));
        }
        public List<Booking> GetBookingsFor(DateTime day)
        {
            return scheduleByDay[day.Date];
        }
    }
}