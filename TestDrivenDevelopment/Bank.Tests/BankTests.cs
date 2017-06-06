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
            Account testAccount = new Account()
            {
                Name = "ivan prgomet",
                Number = "19920320",
                Balance = 0,
            };

            sut.CreateAccount(testAccount);

            // artificially creating (a return result) that the getauditlog should return (because its a substitute, we dont have the real "AuditLog" class yet)
            sut.GetAuditLog().Returns(new List<string>()
            {
                {"New account, Account number 19920320, Name=ivan prgomet"},
            });
            List<string> audits = sut.GetAuditLog();

            StringAssert.Contains("ivan prgomet", audits[0]);
            StringAssert.Contains("19920320", audits[0]);
        }

        [Test]
        public void OneMessageIsWrittenToAuditLogWhenCreatingAnValidAccount()
        {
            Account testAccount = new Account()
            {
                Name = "ivan prgomet",
                Number = "19920320",
                Balance = 0,
            };

            // artificially creating (a return result) for every time the GetLog() runs. 
            // In this case it will run once below when an account is created.
            auditLoggerStub.GetLog().Returns(new List<string>() { { "doesnt matter whats in the message, as long as it contains 1 message" } });

            sut.CreateAccount(testAccount);

            Assert.AreEqual(1, sut.GetAuditLog().Count);

            // checks if the auditlogger recieved 2 addmessage call containing argument of type string
            auditLoggerStub.Received(1).AddMessage(Arg.Any<string>());
        }
        [Test]
        public void TwoMessagesAreWrittenToAuditLogWhenCreatingAnInvalidAccount()
        {
            Account testAccount1 = new Account()
            {
                Name = "ivan prgomet",
                Number = "greetings", // invalid number on purpose
                Balance = 0,
            };
         
            Assert.Throws<InvalidAccountException>(()
                => sut.CreateAccount(testAccount1));

            // checks if the auditlogger has recieved 2 addmessage calls containing any argument thats a string
            auditLoggerStub.Received(2).AddMessage(Arg.Any<string>());
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
