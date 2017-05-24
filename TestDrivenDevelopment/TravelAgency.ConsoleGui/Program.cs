using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.ConsoleGui
{
    class Program
    {
        static void Main(string[] args)
        {
            TourSchedule schedule = new TourSchedule();
            schedule.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            schedule.CreateTour("Bahama mama tour", new DateTime(2013, 4, 10, 10, 15, 0), 20);
            schedule.CreateTour("le swahili tour", new DateTime(2013, 6, 12, 10, 15, 0), 12);
            schedule.CreateTour("tour de france", new DateTime(2013, 1, 1, 10, 15, 0), 80);

            List<Tour> tours = schedule.GetToursFor(new DateTime(2013, 1, 1));
            foreach (var t in tours)
            {
                Console.WriteLine($"name: {t.Name}\ndate: {t.When}\nseats: {t.AvailableSeats}\n\n");
            }

            

        }
    }
}
