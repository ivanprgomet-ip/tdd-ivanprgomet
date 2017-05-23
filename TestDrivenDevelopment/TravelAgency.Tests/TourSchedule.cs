using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.Tests
{
    public class TourSchedule
    {
        List<Tour> _tours = new List<Tour>();

        public void CreateTour(string tourName, DateTime when, int availableSeats)
        {
            _tours.Add(new Tour()
            {
                Name = tourName,
                When = when,
                AvailableSeats = availableSeats,
            });
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            // The date variable will contain the date, the time part will be ignored
            return _tours
                .Where(t=>t.When.Date == dateTime.Date)
                .ToList();
        }
    }
}