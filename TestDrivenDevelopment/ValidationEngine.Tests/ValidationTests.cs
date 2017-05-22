using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationEngine.Tests
{
    // <metoden som man ska anropa>_<scenario>_<utfall>

    [TestFixture]
    public class ValidationTests
    {
        [Test]
        public void TrueForValidAddress()
        {
            // arrange
            Validator sut = new Validator();

            // act
            bool isValid = sut.ValidateEmailAddress("ivanprgomet@hotmail.com");

            // assert
            Assert.IsTrue(isValid, "email is invalid");
        }

        [Test]
        public void EmailContainingNullOrEmptyStringShouldReturnFalse()
        {
            Validator sut = new Validator();

            Assert.Throws<EmailIsNullOrEmptyException>(() =>
            {
                sut.ValidateEmailAddress("");
            });
        }

        [Test]
        public void EmailWithoutAtSymbolShouldReturnFalse()
        {
            Validator sut = new Validator();

            Assert.Throws<EmailContainsNoAtSymbolException>(() =>
            {
                sut.ValidateEmailAddress("Test.com");
            });
        }

        [Test]
        public void EmailWithoutDotStringShouldReturnFalse()
        {
            Validator sut = new Validator();

            Assert.Throws<EmailContainsNoDotStringException>(() =>
            {
                sut.ValidateEmailAddress("name@test");
            });
        }

        [Test]
        public void EmailWithDotBeforeAtSymbolShouldReturnFalse()
        {
            Validator sut = new Validator();

            Assert.Throws<EmailContainingDotInFirstPartOfAddressException>(() =>
            {
                sut.ValidateEmailAddress("name.test@com");
            });
        }

        [Test]
        public void EmailContainingDigitsBeforeAtSymbolShouldReturnFalse()
        {
            Validator sut = new Validator();

            Assert.Throws<EmailContainingDigitsException>(() =>
            {
                sut.ValidateEmailAddress("Name2015@test.com");
            });
        }

        [Test]
        public void EmailContainingDigitsAfterAtSymbolShouldReturnFalse()
        {
            Validator sut = new Validator();

            Assert.Throws<EmailContainingDigitsException>(() =>
            {
                sut.ValidateEmailAddress("Name@test2015.com");
            });
        }
    }
}
