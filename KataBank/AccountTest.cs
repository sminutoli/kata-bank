using System;
using NUnit.Framework;

namespace KataTwitterV2.Bank
{
    [TestFixture]
    public class AccountTest
    {
        private Account _account;

        [Test]
        public void GivenAccountWithBalance_WhenDeposit_AddsAmount()
        {
            GivenAccountWithBalance(100);
            WhenDeposit(10);

            var actual = _account.GetBalance();
            var expected = 110;
            
            Assert.AreEqual(expected, actual);
        }

        private void WhenDeposit(int amount)
        {
            _account.Deposit(amount);
        }

        [Test]
        public void GivenAccountWithBalance_WhenDepositANegativeAmount_ThrowsArgumentException()
        {
            GivenAccountWithBalance(100);
            Assert.Throws<ArgumentException>(() => _account.Deposit(-10));
        }
        
        [Test]
        public void GivenAccountWithBalance_WhenWithdraw_SubstractsAmount()
        {
            GivenAccountWithBalance(100);
            _account.Withdraw(10);

            var actual = _account.GetBalance();
            var expected = 90;
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void GivenAccountWithBalance_WhenWithdrawANegativeAmount_ThrowsArgumentException()
        {
            GivenAccountWithBalance(100);
            Assert.Throws<ArgumentException>(() => _account.Withdraw(-10));
        }
        
        [Test]
        public void GivenAccountWithBalance_WhenWithdrawMoreThanBalance_ThrowsInvalidOperationException()
        {
            GivenAccountWithBalance(100);
            TestDelegate mustThrow = () => _account.Withdraw(101);
            Assert.Throws<InvalidOperationException>(mustThrow);
        }

        private void GivenAccountWithBalance(int balance)
        {
            _account = new Account(balance);
        }
    }
}
