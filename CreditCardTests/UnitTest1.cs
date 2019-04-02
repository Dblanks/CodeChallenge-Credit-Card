using System;
using CreditCard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreditCardTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void OnePerson_3Cards()
        {
            Person person = new Person
            {
                FirstName = "Some",
                LastName = "Guy"
            };

            _CreditCard cc = new _CreditCard
            {
                Balance = 100
            };

            Wallet wallet = new Wallet();
            wallet.IsVisaCardHolder = true;
            wallet.IsMasterCardHolder = true;
            wallet.IsDiscoverCardHolder = true;

            wallet.CalculateSimpleInterest(person, cc);
            wallet.CalculateSimpleInterestVisa(person, cc);
            wallet.CalculateSimpleInterestMasterCard(person, cc);
            wallet.CalculateSimpleInterestDiscover(person, cc);


            Assert.AreEqual(wallet.Value, 16);
            Assert.AreEqual(wallet.VisaSimpleInterest, 10);
            Assert.AreEqual(wallet.MasterSimpleInterest, 5);
            Assert.AreEqual(wallet.DiscoverSimpleInterest, 1);
        }

        [TestMethod]
        public void OnePersonTwoWallets()
        {
            Person person = new Person
            {
                FirstName = "Some",
                LastName = "GuyWithTwoWallets",
            };

            _CreditCard cc = new _CreditCard
            {
                Balance = 100
            };

            Wallet wallet1 = new Wallet();
            wallet1.IsVisaCardHolder = true;
            wallet1.IsDiscoverCardHolder = true;

            Wallet wallet2 = new Wallet();
            wallet2.IsMasterCardHolder = true;


            wallet1.CalculateSimpleInterest(person, cc);
            var wallet1_SI = wallet1.Value;

            wallet2.CalculateSimpleInterest(person, cc);
            var wallet2_SI = wallet2.Value;

            var totalInterest = wallet1.Value + wallet2.Value;


            Assert.AreEqual(totalInterest, 16);
            Assert.AreEqual(wallet1_SI, 11);
            Assert.AreEqual(wallet2_SI, 5);
           
        }

        [TestMethod]
        public void TwoPeopleDifferentWallets()
        {
            Person person1 = new Person
            {
                FirstName = "Lindsay",
                LastName = "Atom"
            };

            Person person2 = new Person
            {
                FirstName = "Joe",
                LastName = "Tester"
            };

            _CreditCard cc = new _CreditCard
            {
                Balance = 100
            };

            Wallet person1Wallet = new Wallet();
            person1Wallet.IsVisaCardHolder = true;
            person1Wallet.IsMasterCardHolder = true;
            person1Wallet.NumOfMasterCards = 2;

            Wallet person2Wallet = new Wallet();
            person2Wallet.IsVisaCardHolder = true;
            person2Wallet.IsMasterCardHolder = true;



            person1Wallet.CalculateSimpleInterest(person1, cc);
            var person1_Wallet_SI = person1Wallet.Value;

            person2Wallet.CalculateSimpleInterest(person2, cc);
            var person2_Wallet_SI = person2Wallet.Value;

            var simpleInterestTotal = person2Wallet.Value + person1Wallet.Value;

            Assert.AreEqual(simpleInterestTotal, 35);
            Assert.AreEqual(person1_Wallet_SI, 20);
            Assert.AreEqual(person2_Wallet_SI, 15);

        }
    }
}
