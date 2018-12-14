using System;
using CodeExemples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private double epsilon = 1e-6;

        [TestMethod]
        public void AccountCannotHaveNegativeOverdraftLimit()
        {
            Account account = new Account(-20);

            Assert.AreEqual(0, account.OverdraftLimit, epsilon);
        }


        [TestMethod]
        public void AccountCannotGetNegativeNumber()
        {
            Account account = new Account(-20);

            Assert.AreEqual(false, account.Deposit(-200));
            Assert.AreEqual(false, account.Withdraw(2100));
        }


        [TestMethod]
        public void AccountCannotOverdraftLimit()
        {
            Account account = new Account(-20);

            Assert.AreEqual(false, account.Withdraw(30));
        }

        [TestMethod]
        public void AccountCorrectWorkDepositAndWidthdraw()
        {
            Account account = new Account(-20);

            Assert.AreEqual(true, account.Deposit(20));
            Assert.AreEqual(true, account.Withdraw(20));

        }


        [TestMethod]
        public void AccountCorrectWorkDepositAndWidthdraw1()
        {
            Account account = new Account(-20);

            Assert.AreEqual(true, account.Deposit(20));
            Assert.AreEqual(20, account.Balance);
            Assert.AreEqual(true, account.Withdraw(20));
            Assert.AreEqual(0, account.Balance);
        }


        [TestMethod]
        public void AccountCorrectrResultWorkDepositAndWidthdraw()
        {
            Account account = new Account(-20);

            Assert.AreEqual(true, account.Deposit(20));
            Assert.AreEqual(true, account.Withdraw(20));

        }
    }
}

