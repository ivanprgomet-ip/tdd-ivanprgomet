using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator sut;
        [SetUp]
        public void Setup()
        {
            // arrange
            sut = new StringCalculator();
        }



        [Test]
        public void ReturnZeroForAnEmtpyString()
        {
            // act
            int sum = sut.Add("");

            // assert
            Assert.AreEqual(0, sum);
        }

        [Test]
        public void AddingOneNumber()
        {
            int sum = sut.Add("5");

            Assert.AreEqual(5, sum);
        }

        [Test]
        public void AddingTwoNumbers()
        {
            int sum = sut.Add("5,5");

            Assert.AreEqual(10, sum);
        }
    }
}
