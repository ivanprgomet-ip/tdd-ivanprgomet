﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.ConsoleGui;

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

        [Test]
        public void SuggestNewDateWhenChoosenDateHasThreeToursAlreadyBooked()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("tour de france", new DateTime(2013, 1, 1, 10, 15, 0), 80);
            sut.CreateTour("tour de Alaska", new DateTime(2013, 1, 1, 10, 15, 0), 80);

            var e = Assert.Throws<TourAllocationException>(()
                => sut.CreateTour("Im should fail tour", new DateTime(2013, 1, 1, 12, 16, 0), 5));

            Assert.AreEqual(new DateTime(2013, 1, 2, 12, 16, 0), e._suggestedTime);
        }

        [Test]
        public void TryingToScheduleATourWithSameNameOnSameDateShouldNotBePossible()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            Assert.Throws<TourWithIdenticalNameFoundException>(()
                => sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 12, 16, 0), 40));
        }

        [Test]
        public void TryingToAddNegativeAmountOfSeatsShouldNotBePossible()
        {
            Assert.Throws<InvalidSeatAmountException>(()
               => sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 12, 16, 0), -10));
        }

        [Test]
        public void TryingToGetToursOnUnbookedDayShouldThrowException()
        {
            var e = Assert.Throws<NoToursFoundForDateException>(() =>
                sut.GetToursFor(new DateTime(2099, 9, 9)));

            Assert.AreEqual("No tours found for the specified date!", e.Message);
        }
    }
}
