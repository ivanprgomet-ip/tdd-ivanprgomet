using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Tests
{
    [TestFixture]
    class BankTests
    {

        private IAuditLogger auditLoggerStub;
        private Bank sut;

        [SetUp]
        public void Setup()
        {
            auditLoggerStub = Substitute.For<IAuditLogger>(); // will get nullreference exception in first testmethod when Adding message to audit logger.
            sut = new Bank(auditLoggerStub);
        }

        [Test]
        public void CanCreateBankAccount()
        {
            Account newAcc = new Account()
            {
                Name = "ivan prgomet",
                Number = "19920320",
                Balance = 0,
            };

            sut.CreateAccount(newAcc);

            Account retrievedAcc = sut.GetAccount("19920320");
            
            // assert
            StringAssert.Contains("ivan prgomet", retrievedAcc.Name);
            StringAssert.Contains("19920320", retrievedAcc.Number);
            Assert.AreEqual(0, retrievedAcc.Balance);

        }

        [Test]
        public void CanNotCreateDuplicateAccounts()
        {
            Account testAccount1 = new Account()
            {
                Name = "ivan prgomet",
                Number = "19920320",
                Balance = 0,
            };
            Account testAccount2 = new Account()
            {
                Name = "lisa simpson",
                Number = "19920320",
                Balance = 50,
            };

            sut.CreateAccount(testAccount1);

            Assert.Throws<DuplicateAccountException>(()
                => sut.CreateAccount(testAccount2));
        }

        [Test]
        public void OneMessageIsWrittenToAuditLogWhenCreatingAnAccount()
        {

        }

        [Test]
        public void OneMessageIsWrittenToAuditLogWhenCreatingAnValidAccount()
        {

        }
        [Test]
        public void TwoMessagesAreWrittenToAuditLogWhenCreatingAnInvalidAccount()
        {

        }

        [Test]
        public void AWarning12AndError45MessageIsWrittenToAuditLogWhenCreatingAnInvalidAccount()
        {

        }

        [Test]
        public void VerifyingThatGetAuditLogGetsTheLogFromTheAuditLogger()
        {

        }
    }
}
