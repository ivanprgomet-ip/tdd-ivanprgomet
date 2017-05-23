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

        }
    }
}
