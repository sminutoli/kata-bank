namespace KataTwitterV2.Bank
{
    public class TransferAmount
    {
        public static void Execute(Account senderAccount, Account receiverAccount, int amount)
        {
            senderAccount.Withdraw(amount);
            receiverAccount.Deposit(amount);
        }
    }
}