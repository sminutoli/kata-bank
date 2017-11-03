using System;
using NUnit.Framework;

namespace KataTwitterV2.Bank
{
    [TestFixture]
    public class TransferAmountTest
    {
        [Test]
        public void GivenTwoAccounts_WhenTransfer_AddsAmountToReceiver()
        {
            var senderAccount = GetAccountByClientId.Execute("pasku123");
            var receiverAccount = GetAccountByClientId.Execute("kamaradaGus");

            var previousBalance = receiverAccount.GetBalance();
            TransferAmount.Execute(senderAccount, receiverAccount, 10);

            var actual = receiverAccount.GetBalance();
            var expected = previousBalance + 10;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenTwoAccounts_WhenTransfer_SustractAmountFromSender()
        {
            var senderAccount = GetAccountByClientId.Execute("pasku123");
            var receiverAccount = GetAccountByClientId.Execute("kamaradaGus");

            var previousBalance = senderAccount.GetBalance();
            TransferAmount.Execute(senderAccount, receiverAccount, 10);

            var actual = senderAccount.GetBalance();
            var expected = previousBalance - 10;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GivenTwoAccounts_WhenTransferNegativeAmount_ThrowsArgumentException_AndBalancesAreNotUpdated()
        {
            var senderAccount = GetAccountByClientId.Execute("pasku123");
            var receiverAccount = GetAccountByClientId.Execute("kamaradaGus");

            var previousReceiverBalance = receiverAccount.GetBalance();
            var previousSenderBalance = senderAccount.GetBalance();
            TestDelegate mustThrow = () => TransferAmount.Execute(senderAccount, receiverAccount, -10);

            Assert.Throws<ArgumentException>(mustThrow);
            Assert.AreEqual(previousReceiverBalance, receiverAccount.GetBalance());
            Assert.AreEqual(previousSenderBalance, senderAccount.GetBalance());
        }

        [Test]
        public void GivenTwoAccounts_WhenTransferAndSenderHasNotEnoughMoney_ThrowsInvalidOperationException_AndBalancesAreNotUpdated()
        {
            var senderAccount = GetAccountByClientId.Execute("pasku123");
            var receiverAccount = GetAccountByClientId.Execute("kamaradaGus");

            var previousReceiverBalance = receiverAccount.GetBalance();
            var previousSenderBalance = senderAccount.GetBalance();
            TestDelegate mustThrow = () => TransferAmount.Execute(senderAccount, receiverAccount, previousSenderBalance + 1);

            Assert.Throws<InvalidOperationException>(mustThrow);
            Assert.AreEqual(previousReceiverBalance, receiverAccount.GetBalance());
            Assert.AreEqual(previousSenderBalance, senderAccount.GetBalance());
        }
    }
}