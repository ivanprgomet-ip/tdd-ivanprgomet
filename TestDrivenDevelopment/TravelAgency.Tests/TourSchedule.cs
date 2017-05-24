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
            if (_tours.Where(t => t.When.Date == when.Date).ToList().Count == 3)
                throw new TourAllocationException(SuggestTimeFor(when));
            else
            {

                _tours.Add(new Tour()
                {
                    Name = tourName,
                    When = when,
                    AvailableSeats = availableSeats,
                });
            }
        }

        private DateTime? SuggestTimeFor(DateTime tried)
        {
            bool foundAvailableDate = false;
            DateTime newSuggestionDate = tried;

            while (!foundAvailableDate)
            {
                // check 1 day ahead until a date for a tour is found
                newSuggestionDate = newSuggestionDate.AddDays(1);

                // check if this date is free (eg. doesnt have three bookings already)
                if (_tours.Where(t => t.When.Date == newSuggestionDate.Date).ToList().Count < 3)
                {
                    foundAvailableDate = true;
                    break;
                }
            }

            if (foundAvailableDate)
                return newSuggestionDate;
            else
                return null;
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            // The date variable will contain the date, the time part will be ignored
            return _tours
                .Where(t => t.When.Date == dateTime.Date)
                .ToList();
        }
    }
}