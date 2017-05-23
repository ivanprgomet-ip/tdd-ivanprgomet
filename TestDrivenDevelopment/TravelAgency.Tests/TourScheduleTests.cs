using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Tests
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule sut;
        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }

        [Test]
        public void CanCreateNewTour()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2013, 1, 1)); // returns all available tours on a given date

            Assert.AreEqual(1, tours.Count);
        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(1, tours.Count);
        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("Bahama mama tour", new DateTime(2013, 4, 10, 10, 15, 0), 20);
            sut.CreateTour("le swahili tour", new DateTime(2013, 6, 12, 10, 15, 0), 12);
            sut.CreateTour("tour de france", new DateTime(2013, 1, 1, 10, 15, 0), 80);

            List<Tour> tours = sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(2, tours.Count);
        }

        [Test]
        public void SchedulingMoreThanThreeToursOnTheSameDateShouldNotBePossible()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("tour de france", new DateTime(2013, 1, 1, 10, 15, 0), 80);
            sut.CreateTour("tour de Alaska", new DateTime(2013, 1, 1, 10, 15, 0), 80);

            Assert.Throws<TourAllocationException>(()
                => sut.CreateTour("Im should fail tour", new DateTime(2013, 1, 1, 12, 16, 0), 5));
        }
    }
}
