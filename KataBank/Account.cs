using System;

namespace KataTwitterV2.Bank
{
    public class Account
    {
        private int _balance;
        public Account(int initialBalance)
        {
            _balance = initialBalance;
        }

        public void Deposit(int amount)
        {
            ValidateAmount(amount);
            UpdateBalance(amount);
        }

        private void UpdateBalance(int amount)
        {
            _balance += amount;
        }

        public int GetBalance()
        {
            return _balance;
        }

        public void Withdraw(int amount)
        {
            ValidateAmount(amount);
            EnsureHasEnoughBalance(amount);
            UpdateBalance(-amount);
        }

        private void ValidateAmount(int amount)
        {
            if (amount < 0) throw new ArgumentException();
        }

        private void EnsureHasEnoughBalance(int amount)
        {
            if (amount > _balance) throw new InvalidOperationException();
        }
    }
}