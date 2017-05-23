using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangerApplication.Tests
{
    [TestFixture]
    public class CoinChangerTests
    {
        [Test]
        public void CorrectChangeWhenUsingOneCoinType()
        {
            // arrange
            var coinTypes = new List<decimal> { 1.0m };
            var sut = new CoinChanger(coinTypes);

            // act
            Dictionary<decimal, int> myChange = sut.MakeChange(14m);

            // assert
            Assert.AreEqual(14, myChange[1.0m]);
        }

        [Test]
        public void CorrectChangeWhenUsingTwoCoinTypes()
        {
            // arrange
            var coinTypes = new List<decimal> { 5.0m, 1.0m };
            var sut = new CoinChanger(coinTypes);

            // act
            Dictionary<decimal, int> myChange = sut.MakeChange(14m);

            // assert
            Assert.AreEqual(4, myChange[1.0m]); // return 4 1's
            Assert.AreEqual(2, myChange[5.0m]); // return 2 5's

        }

        [Test]
        public void CorrectChangeWhenUsingThreeCoinTypes()
        {
            // arrange
            var coinTypes = new List<decimal> { 5.0m, 3.0m, 1.0m };
            var sut = new CoinChanger(coinTypes);

            // act
            Dictionary<decimal, int> myChange = sut.MakeChange(14m);

            // assert
            Assert.AreEqual(1, myChange[1.0m]);
            Assert.AreEqual(1, myChange[3.0m]);
            Assert.AreEqual(2, myChange[5.0m]);
        }
    }
}
