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

        [Test]
        public void CorrectChangeWhenPassingCoinTypesInDifferentOrder()
        {
            // arrange
            var coinTypes = new List<decimal> { 3.0m, 1.0m, 5.0m };
            var sut = new CoinChanger(coinTypes);

            // act
            Dictionary<decimal, int> myChange = sut.MakeChange(14m);

            // assert
            Assert.AreEqual(1, myChange[1.0m]);
            Assert.AreEqual(1, myChange[3.0m]);
            Assert.AreEqual(2, myChange[5.0m]);
        }

        [Test]
        public void CorrectChangeWhenPassingACurrencyThatIsntAWholeNumber()
        {
            // arrange
            var coinTypes = new List<decimal> { 0.25m, 0.50m, 1.00m, 5.00m };
            var sut = new CoinChanger(coinTypes);

            // act
            Dictionary<decimal, int> myChange = sut.MakeChange(13.75m);

            // assert
            Assert.AreEqual(2, myChange[5.0m]);
            Assert.AreEqual(3, myChange[1.00m]);
            Assert.AreEqual(1, myChange[0.50m]);
            Assert.AreEqual(1, myChange[0.25m]);

        }

        [Test]
        public void CorrectChangeWhenPassingACurrencyThatIsntAWholeNumberUnsortedCoinTypes()
        {
            // arrange
            var coinTypes = new List<decimal> { 1.00m, 0.50m, 0.25m, 5.00m };
            var sut = new CoinChanger(coinTypes);

            // act
            Dictionary<decimal, int> myChange = sut.MakeChange(13.75m);

            // assert
            Assert.AreEqual(2, myChange[5.0m]);
            Assert.AreEqual(3, myChange[1.00m]);
            Assert.AreEqual(1, myChange[0.50m]);
            Assert.AreEqual(1, myChange[0.25m]);
        }

        //[Test]
        //public void ReturnFalseWhenThereWillBeAnUnavoidableRest()
        //{
        //    // arrange
        //    var coinTypes = new List<decimal> { 5.00m };
        //    var sut = new CoinChanger(coinTypes);

        //    // act & assert
        //    Assert.Throws<UnavoidableRestDetectedException>(() =>
        //    {
        //        sut.MakeChange(12.00m);
        //    });
        //}
    }
}
