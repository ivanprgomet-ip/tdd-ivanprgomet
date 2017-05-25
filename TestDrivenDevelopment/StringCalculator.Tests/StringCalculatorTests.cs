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


        [Test]
        public void AddingUnknownAmountOfNumbers()
        {
            int sum = sut.Add("5,5,3,7,4,9");

            Assert.AreEqual(33, sum);
        }

        [Test]
        public void AddMethodWorksWithBothNewlineAndCommas()
        {
            int sum = sut.Add("5\n2,2");

            Assert.AreEqual(9, sum);
        }

        [Test]
        public void AddMethodWithOptionalCustomDelimiterShouldWork()
        {
            /// 1. To change a delimiter, the beginning of the string 
            /// will contain a separate line that looks like this:   
            /// “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return 
            /// three where the default delimiter is ‘;’ .
            /// 
            /// 2.The first line is optional. all existing scenarios should still be supported

            int sum = sut.Add("//;\n1;2");

            Assert.AreEqual(3, sum);
        }

        [Test]
        public void CallingAddWithNegativeNumbersShouldThrowException()
        {
            var e = Assert.Throws<NegativesNotAllowedException>(()
                => sut.Add("-1,-5"));

            StringAssert.Contains("negatives not allowed -1 -5", e.Message);
        }

    }
}
