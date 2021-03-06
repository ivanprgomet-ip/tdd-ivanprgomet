﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway.Tests
{
    [TestFixture]
    public class SubwayTests
    {
        [Test]
        public void TouchingInDecrementsBalance()
        {
            // ARRANGE
            var sut = new TravelCard(15);

            // Touch in/out a couple of times 
            // ACT
            sut.TouchIn();
            sut.TouchOut();
            sut.TouchIn();
            sut.TouchOut();

            // ASSERT
            Assert.AreEqual(13, sut.TravelBalance, "Got decremented balance");
        }


        [Test]
        public void MultipleTouchInsNotAllowed()
        {
            var sut = new TravelCard(5);
            Assert.Throws<AlreadyTouchedInException>(() => 
            {
                sut.TouchIn();
                sut.TouchIn();
            });
        }
    }
}
