using System;
using System.Collections.Generic;

namespace TravelAgency.ConsoleGui
{
    public interface ITourSchedule
    {
        void CreateTour(string tourName, DateTime when, int availableSeats);
        List<Tour> GetToursFor(DateTime dateTime);
    }
}