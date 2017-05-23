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
        [Test]
        public void CanCreateNewTour()
        {
            TourSchedule sut = new TourSchedule();

            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);

            List<Tour> tours = sut.GetToursFor(new DateTime(2013, 1, 1)); // returns all available tours on a given date

            Assert.AreEqual(1, tours.Count);

        }
    }
}
