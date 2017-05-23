using System;
using System.Collections.Generic;

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
            return _tours;
        }
    }
}