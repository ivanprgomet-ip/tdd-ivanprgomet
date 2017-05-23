using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Tests
{
    [TestFixture]
    public class ScheduleTests
    {
        private Schedule sut;
        /// <summary>
        /// The Setup method will be executed before each and every test in the class. 
        /// You should only have one setup method per class
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // arrange
            sut = new Schedule();

            // act
            sut.OpenOn(new DateTime(2012, 10, 14));
        }

        [Test]
        public void CanMakeABookingOnAnOpenDay()
        {

            // act - continued from setup
            sut.MakeBooking("Dave", new DateTime(2012, 10, 14, 10, 0, 0), TimeSpan.FromMinutes(45));

            var bookings = sut.GetBookingsFor(new DateTime(2012, 10, 14));

            // assert
            Assert.AreEqual(1, bookings.Count, "Have a single booking");
            Assert.AreEqual("Dave", bookings[0].Name);
        }

        [Test]
        public void MultipleBookingsRetrievedInTimeOrder()
        {
            sut.MakeBooking("Dave", new DateTime(2012, 10, 14, 10, 0, 0), TimeSpan.FromMinutes(45));
            sut.MakeBooking("Tina", new DateTime(2012, 10, 14, 9, 0, 0), TimeSpan.FromMinutes(60));
            var bookings = sut.GetBookingsFor(new DateTime(2012, 10, 14));

            Assert.AreEqual(2, bookings.Count, "Have two bookings");
            Assert.AreEqual("Tina", bookings[0].Name);
            Assert.AreEqual("Dave", bookings[1].Name);
        }
    }

}
