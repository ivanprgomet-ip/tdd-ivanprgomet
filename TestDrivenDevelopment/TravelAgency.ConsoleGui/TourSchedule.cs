using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgency.ConsoleGui
{
    public class TourSchedule : ITourSchedule
    {
        private List<Tour> _tours = new List<Tour>();

        public void CreateTour(string tourName, DateTime when, int availableSeats)
        {
            if (SameNameOnSameDateFound(tourName, when))
                throw new TourWithIdenticalNameFoundException("This date already has a tour with an identical name!");
            if (availableSeats < 1)
                throw new InvalidSeatAmountException($"{availableSeats} is an invalid seat count!");
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

        private bool SameNameOnSameDateFound(string tourName, DateTime when)
        {
            foreach (var t in _tours)
            {
                if (t.Name == tourName && t.When.Date == when.Date)
                    return true;
            }
            return false;
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
            if (_tours.Where(t => t.When.Date == dateTime.Date).ToList().Count == 0)
                throw new NoToursFoundForDateException("No tours found for the specified date!");
            else
            {
                return _tours
                    .Where(t => t.When.Date == dateTime.Date)
                    .ToList();
            }
        }
    }
}